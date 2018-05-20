using System;

namespace BinaryTree
{
    class BTree
    {
        Node root;

        public void add(int key){

            Node newNode = new Node(key);
            if(root == null){
                root = newNode;
                return;
            }

            Node curr = root;

            while(curr != null){
                if(curr.key > key){
                    if(curr.left != null){
                        curr = curr.left;
                    }
                    else{
                        curr.left = newNode;
                        break;
                    }
                }
                else{
                    if(curr.right != null){
                        curr = curr.right;
                    }
                    else{
                        curr.right = newNode;
                        break;
                    }
                }
            }
        }

        public bool find(int key){

            if(root == null){
                return false;
            }

            Node curr = root;

            while(curr != null){
                if(curr.key == key){
                    return true;
                }
                
                if(curr.key > key){
                    if(curr.left != null){
                        curr = curr.left;
                    }
                    else{
                        return false;
                    }
                }
                else{
                    if(curr.right != null){
                        curr = curr.right;
                    }
                    else{
                        return false;
                    }
                }
            }
            return false;
        }

        public int height(Node curr){

            if(curr == null){
                return -1;
            }
            return 1 + Math.Max(height(curr.left),height(curr.right));
        }

        public int visible(Node curr){

            if(curr == null){
                return 0;
            }

            return curr.key >= root.key ? 1 + visible(curr.left) + visible(curr.right) : 0;
        }

        public int amplitude(Node curr){

            if(curr == null){
                return 0;
            }

            return Math.Max(Math.Max(curr.key,max(curr.left)) - Math.Min(curr.key,min(curr.left)),
            Math.Max(curr.key,max(curr.right)) - Math.Min(curr.key,min(curr.right)));

        }

        public int max(Node child){

            if(child == null){
                return Int32.MinValue;
            }

            return Math.Max(child.key,Math.Max(max(child.left),max(child.right)));

        }

        public int min(Node child){

            if(child == null){
                return Int32.MaxValue;
            }

            return Math.Min(child.key,Math.Min(min(child.left),min(child.right)));

        }

        public int maxSubMin(Node curr){

            if(curr == null){
                return 0;
            }

            return max(curr) - min(curr);
        }

        public int sum(Node curr){
            
            if(curr == null){
                return 0;
            }

            return curr.key + sum(curr.left) + sum(curr.right);
        }

        public static void traverse(Node curr){

            if(curr != null){
                traverse(curr.left);
                Console.WriteLine(curr.print());
                traverse(curr.right);               
            }

        }

        static void Main(string[] args)
        {
           
            BTree tree = new BTree();
            tree.add(11);
            tree.add(8);
            tree.add(4);
            tree.add(5);
            tree.add(9);
            tree.add(14);
            tree.add(12);
            tree.add(17);      

            if(tree.find(6)){
                Console.WriteLine("Found");
            }
            else{
                Console.WriteLine("Not Found.");
                traverse(tree.root);
            }

            Console.WriteLine("Tree Height   : " + tree.height(tree.root));
            Console.WriteLine("Visible Nodes : " + tree.visible(tree.root));
            Console.WriteLine("Amplitude     : " + tree.amplitude(tree.root));
            Console.WriteLine("Max - Min     : " + tree.maxSubMin(tree.root));
            Console.WriteLine("Tree Sum      : " + tree.sum(tree.root));

        }
    }

    class Node{

        public Node left;
        public Node right;
        public int key;
        public Node(int key){
            this.key = key;
        }

        public String print(){
            return key + "";
        }
    }
}
