using System.Collections;
using System.Collections.Generic;

namespace HashTable
{
    class HashMap <K, V>
    {
        private static readonly int INIT_BUCKET_COUNT = 16;
        private static readonly double LOAD_FACTOR = 0.5;
        private Bucket[] buckets;
        private int size;

        public HashMap(){
            buckets = new HashMap<K, V>.Bucket[INIT_BUCKET_COUNT];
        }
        public class Entity{
            public K? key;
            public V? value;
        }

        public class Bucket{
            public Node head;
            public class Node{
                internal Node next;
                public Entity  value;
            }

            public V Add(Entity entity){
                Node node = new Node();
                node.value = entity;

                if(head == null){
                    head = node;
                    return default(V);
                }

                Node currentNode = head;
                while(true){
                    if(currentNode.value.key.Equals(entity.key)){
                        V buf = currentNode.value.value;
                        currentNode.value.value = entity.value;
                        return buf;
                    }
                    if(currentNode.next != null){
                        currentNode = currentNode.next;
                    }
                    else{
                        currentNode.next = node;
                        return default(V);
                    }
                }
            }

            public V Remove(K key){
                if(head == null){
                    return default(V);
                }
                if(head.value.key.Equals(key)){
                    V buf = head.value.value;
                    head = head.next;
                    return buf;
                }
                else{
                    Node node = head;
                    while(node != null){
                        if(node.next.value.key.Equals(key)){
                            V buf = node.next.value.value;
                            node.next = node.next.next;
                            return buf;
                        }
                        node = node.next;
                    }
                    return default(V);
                }
            }

            public V Get(K key){
                Node node = head;
                while(node != null){
                    if(node.value.key.Equals(key)){
                        return node.value.value;
                    }
                    node = node.next;
                }
                return default(V);
            }
        }

        public IEnumerator GetEnumerator(){
            for (int i = 0; i < buckets.Length; i++)
            {
                if(buckets[i] == null) continue;
                Bucket bucket = buckets[i];
                Bucket.Node node = bucket.head;
                while(node != null){
                    yield return node.value;
                    node = node.next;
                }
            }
        }

        private int CalculateBucketIndex(K key) => Math.Abs(key.GetHashCode()) % buckets.Length;

        private void Recalculate(){
            size = 0;
            Bucket[] old = buckets;
            buckets = new HashMap<K, V>.Bucket[old.Length * 2];

            for (int i = 0; i < old.Length; i++)
            {
                Bucket bucket = old[i];

                if(bucket != null){
                    Bucket.Node node = bucket.head;
                    while(node != null){
                        Put(node.value.key, node.value.value);
                        node = node.next;
                    }
                }
            }
        }

        public V Put(K key, V value){
            if(size >= buckets.Length * LOAD_FACTOR){
                Recalculate();
            }

            int index = CalculateBucketIndex(key);
            Bucket bucket = buckets[index];
            if(bucket == null){
                bucket = new Bucket();
                buckets[index] = bucket;
            }

            Entity entity = new Entity();
            entity.key = key;
            entity.value = value;

            V buf = bucket.Add(entity);
            if(buf == null){
                size++;
            }
            return buf;
        }

        public V Get(K key){
            int index = CalculateBucketIndex(key);
            Bucket bucket = buckets[index];

            if(bucket == null){
                return default(V);
            }
            return bucket.Get(key);
        }

        public V Remove(K key){
            int index = CalculateBucketIndex(key);
            Bucket bucket = buckets[index];

            if(bucket == null){
                return default(V);
            }

            V buf = bucket.Remove(key);
            if(buf != null){
                size--;
            }
            return buf;
        }
    }
}