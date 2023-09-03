using System.Text;

namespace LinkedList
{
    class LinkedList<T> 
    {
        public Node head;
        public int count = 0;
        public class Node{
            public Node next;
            public T value;
        }

        public void AddFirst(T value){
            Node node = new Node();
            node.value = value;
            count++;
            if(head != null){
                node.next = head;
            }
            head = node;
        }

        public void RemoveFirst(){
            if(head != null){
                head = head.next;
                count--;
            }
        }

        public void AddLast(T value){
            Node node = new Node();
            node.value = value;
            if(head == null){
                head = node;
            }
            else {
                Node lastNode = head;
                while(lastNode.next != null){
                    lastNode = lastNode.next;
                }
                lastNode.next = node;
                count++;
            }
        }

        public void RemoveLast(){
            if(head == null)
                return;
            Node node = head;

            while(node.next != null){
                if(node.next.next == null){
                    node.next = null;
                    return;
                }
                node = node.next;
            }
            count--;
        }

        public bool Contains(T value){
            if(head == null){
                return false;
            }
            else{
                Node node = head;
            while(node != null){
                if(node.value.Equals(value))
                    return true;
                node = node.next;
            }
            return false;
            }
        }

        public void Sort(IComparer<T> comparator){
            Node node = head;
            while(node != null){
                Node minValueNode = head;
                Node node2 = node.next;
                
                while(node2 != null){
                    if(comparator.Compare(minValueNode.value, node2.value) < 0) {
                        minValueNode = node2;
                    }
                    node2 = node2.next;
                }

                if(minValueNode != node){
                    T buf = node.value;
                    node.value = minValueNode.value;
                    minValueNode.value = buf;
                }

                node = node.next;
            }
        }

        public void Reverse(){
            if(head == null){
                return;
            }
            Node newHead = FindLastNode();
            Node temp = newHead;
            while(true){
                Node buf = FindLastNode();
                if(buf == null)
                    break;
                else{
                    temp.next = buf;
                }
                temp = temp.next;
            }
            head = newHead;
        }

        private Node FindLastNode(){
            if(head == null)
                return null;
            Node node = head;
            Node buf;
            while(node.next != null){
                if(node.next.next == null){
                    buf = node.next;
                    node.next = null;
                    count--;
                    return buf;
                }
                else
                    node = node.next;
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            Node node = head;
            while(node != null){
                sb.Append(node.value);
                node = node.next;
                if(node != null)
                    sb.Append("\n");
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}