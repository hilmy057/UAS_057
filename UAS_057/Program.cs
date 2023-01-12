using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*1*/
namespace DoubleLinkList
{
    class Node
    {
        /*Node class represents the node of doubly linked list.
         * It consists of the infromaton part and links to
         * Its succeeding and preceeding nodes
         * in terms of next and previous nodes*/
        public int rollNumber;
        public int tanggal;
        public string name;
        public int jumlah;
        public string alamat;
        public Node next;/*points to the succeeding node*/
        public Node prev;/*points to the preceeding node*/
    }
    class DoubleLinkedList
    {
        Node START;
        public DoubleLinkedList()
        {
            START = null;
        }
        public void addNode()/*Adds a new node*/
        {
            int rollNo;
            string nm;
            int jmlh;
            string almt;
            int tgl;
            Console.Write("\nMasukkan urutan pelanggan : ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama Pelanggan : ");
            nm = Console.ReadLine();
            Console.Write("\nMasukkan Nomor telepon  Pelanggan  : ");
            jmlh = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan jenis kelamin pelanggan  : ");
            almt = Console.ReadLine();
            Console.Write("\nMasukkan id        pelanggan : ");
            tgl = Convert.ToInt32(Console.ReadLine());
            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;
            newnode.jumlah = jmlh;
            newnode.alamat = almt;
            newnode.tanggal = tgl;
            /*Checks if the list is empty*/
            if (START == null || rollNo <= START.rollNumber)
            {
                if ((START != null) && (rollNo == START.rollNumber))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }
            Node previous, current;
            for (current = previous = START; current != null &&
                rollNo >= current.rollNumber; previous = current, current =
                current.next)
            {
                if (rollNo == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return;
                }
            }
            /*On the execution of the ebove for loop, prev and 
             * * current will point to those node
             * between which the new node is to be inserted*/
            newnode.next = current;
            newnode.prev = previous;

            /*If the node is to be inserted at the end of the list*/
            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }

        /*Checks wheteher the specified node is present*/
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                rollNo != current.rollNumber; previous = current,
                current = current.next)
            { }
            /*the above for loop traverse the lis. if the specified node
             * is found then the funciton returns true, otherwise false*/
            return (current != null);
        }

        public bool delNode(int rollNo)/*Deletes the specified node*/
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            if (current == START)/*if the first node is to be deleted*/
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            if (current.next == null)/*if the last node is to be deleted*/
            {
                previous.next = null;
                return true;
            }

            /*if the node to be deleted is in between the list then the following lines of code is executed*/
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }

        public void traverse()/*Traverse the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the ascending order of " +
                    "roll numbers are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + "  "
                        + currentNode.name + " " + currentNode.jumlah + " " + currentNode.alamat + " " + currentNode.tanggal + "\n");
            }
        }

        /*traverse the list in the reverse direction*/
        public void retraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the ascending order of " +
                    "roll numbers are:\n");
                Node currentNode;
                for (currentNode = START; currentNode.next != null;
                    currentNode = currentNode.next)
                { }
                while (currentNode != null)
                {
                    Console.Write(currentNode.rollNumber + "  "
                         + currentNode.name + " " + currentNode.jumlah + " " + currentNode.alamat + " " + currentNode.tanggal + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n Menu" +
                        "\n 1. Add a record to the list" +
                        "\n 2. Delete records from the list" +
                        "\n 3. View all records in the ascending order of roll numbers" +
                        "\n 4. View all records in the descending order of roll numbers" +
                        "\n 5. Search for  record in the list" +
                        "\n 6. Exit \n" +
                        "\n Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.WriteLine("\nEnter the roll number of the costumer " +
                                    "whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number" + rollNo + "deleted \n");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                obj.retraverse();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nMasukkan nomor urutan pelanggan yang ingin anda cari : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);
                                    Console.WriteLine("\nnomor telepon : " + curr.jumlah);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception )
                {
                    Console.WriteLine("Check for the values entered.");
                }
            }
        }
    }
}
