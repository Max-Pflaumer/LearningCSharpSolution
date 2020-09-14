using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LearningCSharp
{
    public class Collections
    {
        [Fact]
        public void MyFavoriteNumbers()
        {
            var myFavoriteNumbers = new ArrayList();
            myFavoriteNumbers.Add(8);
            myFavoriteNumbers.Add(20);
            myFavoriteNumbers.Add(108);

            Assert.Equal(8, myFavoriteNumbers[0]);
            myFavoriteNumbers[1] = 22;
            Assert.Equal(22, myFavoriteNumbers[1]);

            myFavoriteNumbers.Add("Taco");

            var firstTwo = ((int)myFavoriteNumbers[0] + (int)myFavoriteNumbers[1]);
            Assert.Equal(30, firstTwo);
        }
        [Fact]
        public void GenericFavoriteNumbers()
        {
            var myFavoriteNumbers = new List<int>();
            //"Parametric Polymorphism" -> Changes shape based on the parameter
            myFavoriteNumbers.Add(8); //Must add int to this
            myFavoriteNumbers.Add(20);
            myFavoriteNumbers.Add(100);

            var firstTwo = myFavoriteNumbers[0] + myFavoriteNumbers[1];
            Assert.Equal(28, firstTwo);
        }
        [Fact]
        public void InitializeAList()
        {
            var myFavoriteFoods = new List<string> { "Tacos", "Beer", "Pizza" };
            Assert.Equal("Beer", myFavoriteFoods[1]);
        }

        [Fact]
        public void EnumeratingTheValuesOfAList()
        {
            var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var total = 0; //Note: There are better ways to sum up things

            foreach(var number in nums)
            {
                total += number;
            }

            Assert.Equal(45, total);
            Assert.Equal(45, nums.Sum()); //Can also sum this way
        }

        [Fact]
        public void UsingADictionary()
        {
            var friends = new Dictionary<char, string>
            {
                {'s', "Sean"},
                {'j', "Jessika" }
            };

            friends.Add('d', "David");

            Assert.Equal("Sean", friends['s']);
            Assert.True(friends.ContainsKey('d'));
            Assert.False(friends.ContainsKey('x'));

            //Enumerate the keys
            foreach(char key in friends.Keys)
            {
                //'s', 'j', 'd'
            }

            //Enumerating the values
            foreach(string value in friends.Values)
            {
                //"Sean", "Jessika", "David"
            }

            //Enumerate through both sets
            foreach(KeyValuePair<char, string> kvp in friends)
            {
                //kvp.Key == 's';
                //kvp.Value == "Sean", etc
            }
        }
    }
}
