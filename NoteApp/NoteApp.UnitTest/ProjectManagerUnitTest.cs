using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoteApp.UnitTest
{
    [TestClass]
    public class ProjectManagerUnitTest
    {
        private ProjectTest project;

        [TestMethod]
        public void ProjectManagerCreate()
        {
            try
            {
                project = new ProjectTest();
                if (project != null)
                    Assert.IsTrue(true, "Класс Project создан");
                else
                    Assert.IsFalse(false, $"Класс Project не создан");
            }
            catch (Exception e)
            {
                Assert.IsFalse(false, $"Класс Project не создан: {e.Message}");
            }
        }

        [TestMethod]
        public void ProjectManagerSave()
        {
            try
            {
                if (project == null) project = new ProjectTest();
                project.Notes.Add(new NoteTest());
                project.Notes.Add(new NoteTest());
                ProjectManagerTest.SaveToFile(project,"testjson.txt");
                bool result = File.Exists("testjson.txt");
                if(result)
                    Assert.IsTrue(result, "Класс Project сохранен");
                else
                    Assert.IsFalse(false, "Класс Project не удалось сохранить");
            }
            catch (Exception e)
            {
                Assert.IsFalse(false, $"Класс Project не создан: {e.Message}");
            }
        }

        [TestMethod]
        public void ProjectManagerLoad()
        {
            try
            {
                if (project == null) project = new ProjectTest();
                bool result = File.Exists("testjson.txt");
                if (result)
                {
                    project = ProjectManagerTest.LoadFromFile("testjson.txt");
                    if(project!=null && project.Notes.Count>0)
                        Assert.IsTrue(result, "Класс Project загружен");
                    else
                        Assert.IsFalse(false, "Класс Project не удалось загрузить");
                }
                else
                    Assert.IsFalse(false, "Класс Project не удалось загрузить");
            }
            catch (Exception e)
            {
                Assert.IsFalse(false, $"Класс Project не создан: {e.Message}");
            }
        }
    }
}
