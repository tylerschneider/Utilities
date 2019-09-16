//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Writing to the console
            Console.WriteLine("Hello, world!");

            //making variables
            var meaningOfLife = 42;
            var smallPi = 3.14f;
            var bigPi = 3.14159265359;
            var vaporWare = "Half Life 3";
            const bool likesPizza = true;

            //making arrays
            string[] writers = { "Anthony", "Brian", "Eric", "Sean" };
            string[] editors = new string[5];
            Console.WriteLine(writers[2]);

            writers[0] = "Ray";
            
            //if statements
            if (likesPizza == false)
            {
                Console.WriteLine("You monster!");
            }

            //conditional, if likesPizza is true, isMonster is false, else it is true
            bool isMonster = (likesPizza == true) ? false : true;

            //for loops
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("C# Rocks!");
            }
            for (int i = 0; i < writers.Length; i++)
            {
                string writer = writers[i];
                Console.WriteLine(writer);
            }

            //foreach loop goes through each writer in the array
            foreach (string writer in writers)
            {
                Console.WriteLine(writer);
            }
            if (meaningOfLife == 42)
            {
                bool inScope = true;
            }

            //structs, uses the methods/functions below
            //gives myPoint two coordinates
            Point2D myPoint = new Point2D();
            myPoint.X = 10;
            myPoint.Y = 20;

            Point2D anotherPoint = new Point2D();
            anotherPoint.X = 5;
            anotherPoint.Y = 15;

            //adds another point's x and y to myPoint
            myPoint.AddPoint(anotherPoint);
            Console.WriteLine(myPoint.X);
            Console.WriteLine(myPoint.Y);

            Point2D yetAnotherPoint = myPoint;
            yetAnotherPoint.X = 100;
            Console.WriteLine(myPoint.X);
            Console.WriteLine(yetAnotherPoint.X);

            //reference point, exists in long term memory rather than short term
            Point2DRef pointRef = new Point2DRef();
            pointRef.X = 20;
            Point2DRef anotherRef = pointRef;
            anotherRef.X = 25;

            Console.WriteLine(pointRef.X);
            Console.WriteLine(anotherRef.X);

            //removing references, garbage cleanup
            pointRef = null;
            anotherRef.X = 125;
            Console.WriteLine(anotherRef.X);
            anotherRef = null;

            //stuct for a person, who inherits the attributes the Person class, including the SayHello function
            RenFairePerson person = new RenFairePerson();
            person.Name = "Igor the Ratcatcher";
            person.SayHello();
        }
    }
    struct Point2D
    {
        public int X;
        public int Y;
        public void AddPoint(Point2D anotherPoint)
        {
            this.X = this.X + anotherPoint.X;
            this.Y = this.Y + anotherPoint.Y;
        }
    }

    class Point2DRef
    {
        public int X;
        public int Y;

        public void AddPoint(Point2DRef anotherPoint)
        {
            this.X = this.X + anotherPoint.X;
            this.Y = this.Y + anotherPoint.Y;
        }
    }

    class Person
    {
        public string Name;
        //uses virtual because a sub-class will override it
        public virtual void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }

    class RenFairePerson : Person
    {
        //overrides the SayHello class in Person to do something else
        public override void SayHello()
        {
            base.SayHello();
            Console.Write("Huzzah!");
        }
    }

    //Vector3 can define a point or end point, magnitude, and direction (start is 0)
    Vector3 myVector = new Vector3(10, 10, 10);

    //Directions
    Vector3.forward; //(0, 0, -1)

    //Lerp uses a start point, endpoint, and a point along the line (0.5f is halfway)
    Vector3 result = Vector3.Lerp(start, end, .5f);
    //use time to animate along the screen
    float timePassed += Time.deltaTime;
    float currentTime = timePassed / 1.0f;
    bullet.position = Vector3.Lerp(startPosition, endPosition, currentTime);
    //Slerp allows for curves

    //transforms
    //localRotation = relative to parent, rotation relative to world, same for scale
    //transform.forward, transform.right, transform.up
    //use * -1 for opposite directions
    Vector3 left = transform.right * -1;
    
    //removes the gameobject from the parent gameobject
    transform.parent = null;
    
    //finds something by name, is slow
    transform enemy = transform.Find("Enemy");
    
    //removes gameobjects from hierarchy without destroying them
    enemy.DetachChildren();

    //default rotation of a quaternion
    Quaternion.identity;

    //sets the rotation of a quaternion using eulerAngles(x, y, and z-axis rotation)
    Quaternion objectRotation = Quaternion.identity;
    objectRotation.eulerAngles = new Vector3(90, 0, 0);
   
    //gameobject can be accessed by its components using transform
    transform.gameObject

    //allows it to be changed in the Unity editor
    [System.Serializable] 
    public class ExplodeBot : ScriptableObject
    {
        public int hitPoints; public float moveSpeed; public float damage;
    }

    //ScriptableObjects
        public class CreateExplodeBot
        {
            // 1 - allows you to explode the bot from the unit menu
            [MenuItem("Assets/Create/Explode Bot")]
            public static ExplodeBot CreateBot()
            {
                // 2 - creates an instance of the ExplodeBot
                ExplodeBot bot = ScriptableObject.CreateInstance<ExplodeBot>();
                // 3 - save the ScriptableObject in the project browser assets for easy access
                AssetDatabase.CreateAsset(bot, "Assets/ExplodeBot.asset");
                AssetDatabase.SaveAssets();
                return bot;
            }
        }

    //requires a omponent, will add the text component automatically and prevent it from being removed
    [RequireComponent(typeof(Text))

    //allows attributes to be accessible in the inspector but not by other scripts
    [SerializeField]

    //hides attributes from the inspector
    [HideInInspector]

    //creates a slider for the number in the inspector
    [Range(1, 100)]
    public int secretNumber;
}