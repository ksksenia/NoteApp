using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoteApp.UnitTest
{
    [TestClass]
    public class ProjectUnitTest
    {
        private ProjectTest project;

        [TestMethod]
        public void ProjectCreate()
        {
            try
            {
                project = new ProjectTest();
                Assert.IsTrue(true, "Класс Project создан");
            }
            catch (Exception e)
            {
                Assert.IsFalse(false, $"Класс Project не создан: {e.Message}");
            }
        }

        [TestMethod]
        public void ProjectInsert()
        {
            try
            {
                if (project == null) ProjectCreate();
                project.Notes.Add(new NoteTest());
                if(project.Notes.Count>0)
                 Assert.IsTrue(true, "Класс Project отредактирован");
                else
                    Assert.IsFalse(false, $"Класс Project не удалось изменить");
            }
            catch (Exception e)
            {
                Assert.IsFalse(false, $"Класс Project не удалось отредактировать: {e.Message}");
            }
        }

        [TestMethod]
        public void ProjectRemote()
        {
            try
            {
                if (project == null) ProjectCreate();
                if(project.Notes.Count==0) project.Notes.Add(new NoteTest());
                int count = project.Notes.Count;
                project.Notes.RemoveAt(count-1);
                if (project.Notes.Count == count-1)
                    Assert.IsTrue(true, "Класс Project отредактирован");
                else
                    Assert.IsFalse(false, $"Класс Project не удалось изменить");
            }
            catch (Exception e)
            {
                Assert.IsFalse(false, $"Класс Project не удалось отредактировать: {e.Message}");
            }
        }

        [TestMethod]
        public void ProjectEdit()
        {
            try
            {
                if (project == null) ProjectCreate();
                project = new ProjectTest();
                project.Notes.Add(new NoteTest());
                if (project.Notes.Count > 0)
                    Assert.IsTrue(true, "Класс Project отредактирован");
                else
                    Assert.IsFalse(false, $"Класс Project не удалось изменить");
            }
            catch (Exception e)
            {
                Assert.IsFalse(false, $"Класс Project не удалось отредактировать: {e.Message}");
            }
        }

        [TestMethod]
        public void ProjectDispose()
        {
            try
            {
                if (project != null)
                {
                    project = null;
                    Assert.IsTrue(true, "Класс Project очищен");
                    return;
                }
                else
                    Assert.IsFalse(false, $"Класс Project не удалось очистить, он пустой");
            }
            catch (Exception e)
            {
                Assert.IsFalse(false, $"Класс Project не удалось очистить: {e.Message}");
            }
        }

    }
}
