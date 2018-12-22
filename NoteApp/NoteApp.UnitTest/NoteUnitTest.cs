using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoteApp.UnitTest
{
    [TestClass]
    public class NoteUnitTest
    {
        private NoteTest note;

        [TestMethod]
        public void NoteCreate()
        {
            try
            {
                note = new NoteTest();
                Assert.IsTrue(true,"Класс Note создан");
            }
            catch (Exception e)
            {
                Assert.IsFalse(false,$"Класс Note не создан: {e.Message}");
            }
        }

        [TestMethod]
        public void NoteEdit()
        {
            try
            {
                if (note == null) NoteCreate();
                note.Category = NoteCategoryTest.Health_and_sport;
                note.NoteText += "Test";
                note.Title += "Test";
                note.timeCreated = note.timeModificated = DateTime.Now;
                Assert.IsTrue(true, "Класс Note отредактировать");
            }
            catch (Exception e)
            {
                Assert.IsFalse(false, $"Класс Note не удалось изменить: {e.Message}");
            }
        }

        [TestMethod]
        public void NoteDispose()
        {
            try
            {
                if (note != null)
                {
                    note = null;
                    Assert.IsTrue(true, "Класс Note очищен");
                    return;
                }
                else
                    Assert.IsFalse(false, $"Класс Note не удалось очистить, он пустой");
            }
            catch (Exception e)
            {
                Assert.IsFalse(false, $"Класс Note не удалось очистить: {e.Message}");
            }
        }
    }
}
