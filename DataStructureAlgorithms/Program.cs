using System.Collections;

// ARRAYS
#region Arrays
//Arrays are static in size.
//Arrays are static in type(all array elements must be of the same type).
// Array size must be known upon declaration time.

string[] arrayStrings = { "Hello", "World!" };

//Array Insertions and Deletions 

//Inserting at the End of an Array

int[] intArray = new int[9];

//Make a variable to keep the length because .Length is based off capacity and does not track  the actual index
int length = 0;

//This adds data for us

for (int i = 0; i < 3; i++)
{
intArray[length] = i;
length++;
}

//Inserting at the End of an Array

for (int i = 3; i >= 0; i--)
{
intArray[i + 1] = intArray[i];
}

intArray[0] = 20;

//To insert value in arrays at specified index

for (int i = 4; i >= 2; i--)
{
intArray[i + 1] = intArray[i];
}
intArray[2] = 8;

//To delete last item

for (int i = 0; i < 3; i++)
{
intArray[length] = i;
length++;
}
length--;

//To delete first item

for (int i = 1; i < length; i++)
{
intArray[i - 1] = intArray[i];
}
length--;

//To insert where ever you want

for (int i = 2; i < length; i++)
{
intArray[i - 1] = intArray[i];
}
length--;

for (int i = 0; i < length; i++)
{
Console.WriteLine(intArray[i]);
}

int value = 0; //To see all values in the debugger stack flow

//Linear Search Array (Sequencial)

int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//key means what value we are searching for 
bool LinearSearch(int[] array, int key)
{
for (int i = 0; i < array.Length; i++)
{
if (array[i] == key)
{
return true;
}
}
return false;
}
Console.WriteLine(LinearSearch(array, 4));


#endregion

// LISTS
#region Lists
// Lists are dynamic in size. 
// Lists are static in type (all list elements must be of the same type). 
// A list's size changes throughout the list's lifecycle.

List<string> list = new List<string>();
list.Add("Hello");
list.Add("World!");

// ARRAY LISTS 
// Array lists are dynamic in size. 
// Array lists are dynamic in type (array list elements can be of different types). 
// An array list's size changes throughout the array list's lifecycle.

ArrayList arrayList = new ArrayList();
arrayList.Add("Hello");
arrayList.Add(1);
#endregion

// LINKED LISTS 
#region Linked Lists
// Linked lists are dynamic in size. 
// Linked lists are static in type (linked list elements must be of the same type). 
// A linked list's size changes throughout the linked list's lifecycle.

public class Node
{
    public int Data { get; set; }
    public Node? Next { get; set; }
    public void DisplayNode()
    {
        Console.WriteLine(Data);
    }
}
//static void main():

//Node nodeA = new();
//nodeA.Data = 10;

//nodeA nodeB = new();
//nodeB.Data = 20;

//nodeA.Next = nodeB;

public class LinkedList
{
    public Node? First { get; set; }
    public void InsertFirst(int data)
    {
        //Create the node 
        Node newNode = new Node();
        // Put the data in the node 
        newNode.Data = data;
        // Put the old node in next 
        newNode.Next = First;
        //Make the first the new node 
        First = newNode;
    }
    public Node DeleteFirst()
    {
        //Assign the temporary variable 
        Node temp = First;
        //Assign the next end
        First = First.Next;
        return temp;
    }

    public void DisplayList()
    {
        Console.WriteLine("Itterating through list...");
        Node current = First;
        while (current != null)
        {
            current.DisplayNode();
            current = current.Next;
        }
    }
    public void InsertLast(int data)
    {
        Node current = First;
        while (current.Next != null)
        {
            current = current.Next;
        }
        Node newNode = new();
        newNode.Data = data;
        current.Next = newNode;
    }
    //static void main():

    //    LinkedList linkedList = new();
    //    linkedList.InsertFirst(101);
    //    linkedList.InsertFirst(202);
    //    linkedList.InsertFirst(303);

    //    linkedList.DeleteFirst();
    //    linkedList.DeleteFirst();

    //    linkedList.InsertLast(777);
    //    linkedList.InsertLast(9);

    //    linkedList.DisplayList();


    //    LinkedList<string> linkedList = new LinkedList<string>();
    //    linkedList.AddFirst("First");
    //    linkedList.AddLast("Last");

    //    var firstOnTheList = linkedList.First;
    //    var next = firstOnTheList.Next;
}
#endregion

// STACKS
#region Stacks
// Stacks are dynamic in size. 
// Stacks are dynamic in type (stack elements can be of different types). 
// A stack's size changes throughout the stack's lifecycle. 
// FILO: First in, last out. 

//static void main():
/*Stack stack = new();
stack.Push("I can add a string"); //First
stack.Push(1); //Second
stack.Push(true); // Third 
var last = stack.Pop();*/


public class Stack
{
    public int MaxSize { get; set; } // Array stacks you need a maxsize to init array 
    //this holds our array 
    public string[] StackArray { get; set; }
    //this keeps track of the top 
    public int Top { get; set; }
    public Stack(int size)
    {
        //This holds constructor value 
        this.MaxSize = size;
        //Creates array with size 
        this.StackArray = new string[MaxSize];
        // We give the top -1 because array is zero index; If we don't it will skip first element 
        this.Top = -1;
    }
    public void Push(string item)
    {
        //
        Top++;
        StackArray[Top] = item;
    }
    public string Pop()
    {
        //Think of placeholde
        int old_top = Top;
        //Decrement for the new top
        Top--;
        return StackArray[old_top];
    }
    public string Peek()
    {
        return StackArray[Top];
    }
    public bool isEmpty()
    {
        return Top == 0;
    }
    public bool isFull()
    {
        return (MaxSize - 1 == Top);
    }

    //static void main():

    /*Stack stack = new(10);

for(int i = 0; i< 3; i++)
{
    stack.Push("First");
    stack.Push("Second");
    stack.Push("Third");
}

stack.Pop();
stack.Peek();

while (!stack.isEmpty())
{
    var val = stack.Pop();
    Console.WriteLine(val);
}*/
}

#endregion

// QUEUES
#region Queues
// Queues are dynamic in size. 
// Queues can be dynamic in type (queue elements can be of different types); 
// A queue's size changes throughout the queue's lifecycle. 
// FIFO: First in, first out.

//static void main():
/*Queue queue = new Queue(); // Dynamic in type
Queue<string> queue2 = new Queue<string>(); // Static in type 

queue.Enqueue("I can add a string"); 
queue.Enqueue(1); 
queue.Enqueue(false);*/

public class Queue
{
    public int MaxSize { get; set; } //Sets the number of elements because this is an array 
    public int[] QueueArray { get; set; } //Actual array we will store elements in 
    public int Front { get; set; } //Index to keep track of front 
    public int Rear { get; set; } //Index to keep track of adds 
    public int NItems { get; set; } //This will keep track of length 
    public Queue(int size)
    {
        this.MaxSize = size;
        this.QueueArray = new int[size];
        Front = 0;
        Rear = -1;
    }

    public void Enqueue(int item)
    {
        //Increment our pointer
        Rear++;
        //Insert into where the rear was incremented
        QueueArray[Rear] = item;
        //Increment
        NItems++;
    }

    public int Dequeue()
    {
        int temp = QueueArray[Front];
        Front++;
        if (Front == MaxSize)
        {
            Front = 0;
        }
        NItems--;
        return temp;
    }
    public int Peek()
    {
        return QueueArray[Front];
    }
}

//static void main():

/*Queue queue = new Queue(10);

queue.Enqueue(1);
queue.Enqueue(3);
queue.Enqueue(12);

queue.Dequeue();

queue.Peek();*/

#endregion

//BINARY SEARCH 
#region Binary search

/*int[] intArray2 = { -22, -15, 2, 7, 20, 30, 54 };

Console.WriteLine(BinarySearch(intArray, 2));

int BinarySearch(int[] intArray, int value)
{
    int start = 0;
    int end = intArray2.Length;
    //start end + while less than is going to criss crossing 
    while (start < end)
    {
        //Put in parenthensis because add them incorrect 
        int midpoint = (start + end) / 2;
        //Search the middle the of the book 
        if (intArray2[midpoint] == value)
        {
            return midpoint;
        }
        else if (intArray2[midpoint] < value)
        {
            start = midpoint + 1;
        }
        else
        {
        end = midpoint;
        }
    }
    return -1;
}*/

#endregion

//BINARY SEARCH TREE
#region Binary Search Tree

/*public class TreeNode
{
    public int Key { get; set; }
    public string Value { get; set; }
    public TreeNode LeftChild { get; set; }
    public TreeNode RightChild { get; set; }
    public TreeNode(int key, string value)
    {
        this.Key = key;
        this.Value = value;
    }
    public class BinarySearchTree
    {
        public TreeNode Root { get; set; } = null;

        public void Insert(int key, string value)
        {
            Root = InsertItem(Root, key, value);
        }

public void PrintPreOrderTraversal()
        {
            PreOrderTraversal(Root);
        }
private void PreOrderTraversal(TreeNode node)
        {
            if(node != null)
            {
                Console.WriteLine(node.Key + " " + node.Value);
                PreOrderTraversal(node.LeftChild);          
                PreOrderTraversal(node.RightChild);
            }
        }

    public void PrintInOrderTraversal()
        {
            InOrderTraversal(Root);
        }
private void InOrderTraversal(TreeNode node)
        {
            if(node != null)
            {
                InOrderTraversal(node.LeftChild);
                Console.WriteLine(node.Key + " " + node.Value);
                InOrderTraversal(node.RightChild);
            }
        }

 public void PrintPostOrderTraversal()
        {
            PostOrderTraversal(Root);
        }
private void PostOrderTraversal(TreeNode node)
        {
            if(node != null)
            {
                PostOrderTraversal(node.LeftChild);
                PostOrderTraversal(node.RightChild);
                Console.WriteLine(node.Key + " " + node.Value);
            }
        }

        public TreeNode InsertItem(TreeNode node, int key, string value)
        {
            TreeNode newNode = new(key, value);
            //If this is the first time, you insert, create the root
            if (node == null)
            {
                node = newNode;
                return node;
            }

            //If this isn't the first insert, traverse, find null, insert
            if (key < node.Key)
            {
                node.LeftChild = InsertItem(node.LeftChild, key, value);
            }
            else
            {
                node.RightChild = InsertItem(node.RightChild, key, value);
            }
            return node;
        }

        public string Find(int key) 
        {
            TreeNode node = Find(Root, key);
            return node == null ? null : node.Value;
        }

        private TreeNode? Find(TreeNode node, int key)
        {
            if (node == null || node.Key == key)
            {
                return node;
            }
            else if (key < node.Key)
            {
                return Find(node.LeftChild, key);
            }
            else if (key > node.Key)
            {
                return Find(node.RightChild, key);
            }
            return null;        
    }
}
BinarySearchTree bst = new();
bst.Insert(7, "Engineer");
bst.Insert(20, "Worker");
bst.Insert(99, "Driver");
bst.Insert(5, "Administrator");
bst.Insert(2, "Accountant");

Console.WriteLine(bst.Find(99));

int value = 0; //To show debugger's stack flow
*/
#endregion

//BUBBLE SORT
#region Bubble sort

/*int[] intArray3 = new int[] { 6, 5, 1, 7, 2, 4 };

Console.WriteLine(BubbleSort(intArray3));
int[] value2 = BubbleSort(intArray3);
int toSee = 0; // to see stack flow

int[] BubbleSort(int[] array)
{
    //hold temporary swap variable. Think state;
    int temp = 0;
    //Iterates over entire loop MANY times
    for (int pointer = 0; pointer < array.Length; pointer++)
    {
        //Forms the "box" that does the comparison
        for(int sort = 0; sort < array.Length - 1; sort++)
        {
            //This checks to see if left side is larger than the right
            if(array[sort] > array[sort + 1])
            {
                //Swap
                //We store variable as temp so we dont overwrite it when we swap
                temp = array[sort + 1];
                //put left variable in the right
                array[sort + 1] = array[sort];
                //Put the right variable in the left
                array[sort] = temp;
            }
        }
    }
    return array;
}*/

#endregion

//RECURSION
#region Recursion
//Function that calls itself
//stack overflow
//When we execute, we push to stack
//When stack is returned, it is popped
//each stack has it's own state of variables
/*
MinusByOne(5);

void MinusByOne(int n)
{
    //Base case is going to prevent a stack overflow
    if(n != 0)
    {
        MinusByOne(n - 1);
    }
    //All these functions are going to execute, store state, then they are going minus
    Console.WriteLine("Call: " + n);
}

Console.WriteLine(RecursiveFactorial(5));

int RecursiveFactorial(int num)
{
    if(num == 0)
    {
        return 1;
    }

    return num * RecursiveFactorial(num - 1);
}
*/
#endregion

//DICTIONARIES
#region Dictionaries
// DICTIONARIES 
// Dictionaries are dynamic in size. 
// Dictionaries are static in type (dictionary elements must be of the same type). 
// A dictionary's size changes throughout the disctionary's lifecycle. 
// Dictionaries have a key, which is associated with a value.

//static void main():

/*Dictionary<string, string> dictionary = new Dictionary<string, string>(); 
dictionary.Add("123", "John"); 
dictionary.Add("321", "Mary"); 

var person = dictionary["123"];
*/
#endregion

//HASHTABLES
#region Hashtables
// HASHTABLES 
// Hashtables are dynamic in size. 
// Hashtables are dynamic in type (hashtable elements can be of different types). 
// A hashtable's size changes throughout the hashtable's lifecycle. 
// Hashtables have a key, which is associated with a value.

//static void main():

/*Hashtable hashtable = new Hashtable(); 
hashtable.Add("123", "John"); 
hashtable.Add(1, true); 
var item = hashtable[1];*/
#endregion