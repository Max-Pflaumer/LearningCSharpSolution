using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LearningCSharp
{
    public class DeclaringVariables
    {
        [Fact]
        public void DeclaringAVariable()
        {
            //dataType identifier
            int age;
            string name;
            age = 23;
            name = "Nate";

            Assert.Equal("Nate", name);
            Assert.Equal(23, age);
            
        }

        [Fact]
        public void InitializingVariables()
        {
            int age = 42;
            string name = "Dale";
            int a = 10, b = 20;
            decimal pay = 42.32M; //Need the M or else it will default to a double and throw an error(Double has more bits than decimal so data could be lost)
            char mi = 'M';
            var herAge = 52; //Implicit data typing, compiler will figure it out(This will be a Int32)
        }
        [Fact]
        public void ValueTypesExample()
        {
            int x = 10;
            int y = x;

            x = 30;

            Assert.Equal(10, y); // value type only gets value, not the reference to variable x
        }

        [Fact]
        public void ReferenceTypeExample()
        {
            Dog x = new Dog() { Name = "Fido" };
            Dog y = x;

            y.Name = "Rover";

            Assert.Equal("Rover", x.Name);
        }

        [Fact]
        public void StringsAreReferenesThatWorkLikeValuesForAssignment()
        {
            string x = "Fido";
            string y = x;

            y = "Rover";

            Assert.Equal("Fido", x);
        }
        
        [Fact]
        public void OtherFunThingsAboutStrings()
        {
            var myName = "jeff";
            var otherName = myName.ToUpper(); //myName string does not change, but this will return a new string
            Assert.Equal("JEFF", otherName);
            Assert.Equal("jeff", myName);

            string lotsOfNumbers = "";
            for(var t = 0; t < 100; t++)
            {
                lotsOfNumbers += t + ","; //Returns huge concatenated string of all the numbers, will create a bunch of strings with new concatenations

            }
        }

        [Fact]
        public void ForBuildingBigStringsUseAStringBuilder()
        {
            StringBuilder builder = new StringBuilder();
            for(var t= 0; t < 100; t++)
            {
                builder.Append($"{t},");
            }

            var otherSb = new StringBuilder("Tacos");
            Assert.Equal("Tacos", otherSb.ToString());
        }
    }
    
    public class Dog
    {
        public string Name;
    } 
}
