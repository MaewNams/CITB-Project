using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CatsInTheBox.DAL;
using System.Data.Entity;
using Inspired.Models;
using InspiredTests.Controllers;

namespace InspiredTests
{
    public class TestSetUp
    {
        public Mock<CatsInTheBoxContext> mockContext { get; set; }
        public TestSetUp()
        {
            mockContext = new Mock<CatsInTheBoxContext>();
        }
        //public static TestSetUp Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new TestSetUp();
        //        }
        //        return instance;
        //    }
        //}
        public void AccountSetUp()
        {
            var fakeModels = new Account[]
            {
                new Account() { id = 1, username = "UserA", password = "123456", email = "a@a.a", address = "1/1 A B C", provinceid = 1, usertypeid = 1 },
                new Account() { id = 2, username = "UserB", password = "123456", email = "b@b.b", address = "1/1 A B C", provinceid = 2, usertypeid = 2 }
            };
            mockContext.Setup(c => c.Account).ReturnsDbSet(fakeModels);
        }
        public void AdopterSetUp()
        {
            var fakeModels = new Account[]
            {
                new Account() { id = 1, username = "UserA", password = "123456", email = "a@a.a", address = "1/1 A B C", provinceid = 1, usertypeid = 1 },
                new Account() { id = 2, username = "UserB", password = "123456", email = "b@b.b", address = "1/1 A B C", provinceid = 2, usertypeid = 2 }
            };
            mockContext.Setup(c => c.Account).ReturnsDbSet(fakeModels);
        }
        public void DiarySetUp()
        {
            var fakeModels = new Diary[]
            {
                new Diary() { id = 1, userid = 1, name = "Diary A", pic = "a.jpg", description = "This is Diary A", timestamp = DateTime.Now },
                new Diary() { id = 2, userid = 2, name = "Diary B", pic = "b.jpg", description = "This is Diary B", timestamp = DateTime.Now }
            };
            mockContext.Setup(c => c.Diary).ReturnsDbSet(fakeModels);
        }
        public void ChapterSetUp()
        {
            var fakeModels = new Chapter[]
                {
                new Chapter() {
                    id = 1,
                    diaryid = 1,
                    name = "Chapter A",
                    detail = "Chapter A Detail",
                    pic1 = "ChapterA1.jpg",
                    pic2 = "ChapterA2.jpg",
                    timestamp = DateTime.Now,
                    views = 1
                  },
                new Chapter() {
                    id = 2,
                    diaryid = 1,
                    name = "Chapter B",
                    detail = "Chapter B Detail",
                    pic1 = "ChapterB1.jpg",
                    pic2 = "ChapterB2.jpg",
                    timestamp = DateTime.Now,
                    views = 1
                  },
                };
            mockContext.Setup(c => c.Chapter).ReturnsDbSet(fakeModels);
        }
        public void CatSetUp()
        {
            var fakeModels = new Cat[]
            {
                new Cat() {
                    id = 1,
                    userid = 1,
                    name = "Cat A",
                    age = "1 Year",
                    lifestage = "Kid",
                    pic = "CatA.jpg",
                    eyecolorid = 1,
                    coatpatternid = 1,
                    tailid = 1,
                    birthdate = DateTime.Now,
                    adoptdate = DateTime.Now,
                    deathdate = DateTime.Now,
                    habit = "Cat A Habit",
                    liked = "Cat A Liked",
                    disliked = "Cat A Disliked",
                    description = "Cat A Description",
                    note = "Cat A Noted",
                    status = 1
                },
                new Cat() {
                    id = 2,
                    userid = 2,
                    name = "Cat B",
                    age = "1 Year",
                    lifestage = "Kid",
                    pic = "CatB.jpg",
                    eyecolorid = 1,
                    coatpatternid = 1,
                    tailid = 1,
                    birthdate = DateTime.Now,
                    adoptdate = DateTime.Now,
                    deathdate = DateTime.Now,
                    habit = "Cat B Habit",
                    liked = "Cat B Liked",
                    disliked = "Cat B Disliked",
                    description = "Cat B Description",
                    note = "Cat B Noted",
                    status = 1
                }
            };
            mockContext.Setup(c => c.Cat).ReturnsDbSet(fakeModels);
        }
        public void CatDiarySetUp()
        {
            var fakeModels = new Catdiary[]
            {
                new Catdiary() { id = 1, catid = 1, diaryid = 1, Cat = new Cat(), Diary = new Diary()},
                new Catdiary() { id = 2, catid = 2, diaryid = 2, Cat = new Cat(), Diary = new Diary()}
            };
            mockContext.Setup(c => c.Catdiary).ReturnsDbSet(fakeModels);
        }
    }
}
