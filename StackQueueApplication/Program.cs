

using StackQueueApplication;

class Program
{
    static void Main(string[] args)
    {
        int msgcount = 0;
        Console.WriteLine("Choose the Operation : \n1: Stack\n2: Queue");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                StackOperation();
                break;
            case 2:
                msgcount += 1;
                QueueOperation();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }

        static void StackOperation()
        {
            Console.WriteLine("Enter the Datatype (int or char)");

            string dataType = Console.ReadLine();

            switch (dataType.ToLower())
            {
                case "int":
                    GenStack<int> intStack = new GenStack<int>(5);
                    StackMenu(intStack);
                    break;
                case "char":
                    GenStack<char> charStack = new GenStack<char>(5);
                    StackMenu(charStack);
                    break;

            }
        }
        static void StackMenu<T>(GenStack<T> stack)
        {
            while (true)
            {
                Console.WriteLine("Choose the operation : \n1: Push\n2: Pop\n3: Peek\n 4: IsEmpty\n5: Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the value ");
                        T value = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                        stack.Push(value);
                        break;
                    case 2:
                        Console.WriteLine("Popped Element  " + stack.Pop());
                        break;
                    case 3:
                        Console.WriteLine("Top Element  " + stack.Peek());
                        break;
                    case 4:
                        Console.WriteLine("Stack is Empty : " + stack.IsEmpty());
                        break;
                    case 5:
                        return;
                }
            }
        }

        static void QueueOperation()
        {
            Console.WriteLine("Enter the size of the queue:");
            int size = int.Parse(Console.ReadLine());

            GenQueue<ChatMessage> chatQueue = new GenQueue<ChatMessage>(size);
            int messageCount = 1;

            while (true)
            {
                Console.WriteLine("Choose the operation : \n1: Enqueue\n2: Dequeue\n3: Peek\n4: IsEmpty\n5: Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        EnqueueMessage(chatQueue, messageCount);
                        messageCount++;
                        break;
                    case 2:
                        if (!chatQueue.IsEmpty())
                        {
                            Console.WriteLine("Dequeued Message:");
                            DisplayMessage(chatQueue.Dequeue());
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty. Cannot dequeue.");
                        }
                        break;
                    case 3:
                        if (!chatQueue.IsEmpty())
                        {
                            Console.WriteLine("Peeked Message:");
                            DisplayMessage(chatQueue.Peek());
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty. Cannot peek.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Queue is Empty: " + chatQueue.IsEmpty());
                        break;
                    case 5:
                        return;
                }
            }
        }

        static void EnqueueMessage(GenQueue<ChatMessage> queue, int messageId)
        {
            ChatMessage message = new ChatMessage();

            message.MessageId = messageId;
            Console.WriteLine("Enter content:");
            message.Content = Console.ReadLine();
            message.TimeStamp = DateTime.Now;
            message.SourceId = messageId;

            queue.Enqueue(message);
        }

        static void DisplayMessage(ChatMessage message)
        {
            Console.WriteLine($"Message ID: {message.MessageId}");
            Console.WriteLine($"Content: {message.Content}");
            Console.WriteLine($"Timestamp: {message.TimeStamp}");
            Console.WriteLine($"Source ID: {message.SourceId}");
            Console.WriteLine();
        }
    }






}

