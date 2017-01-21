using System;
using NUnit.Framework;
using Tasklist.Domain.Entities;

namespace TaskList.Tests.DAL.SQL
{
    [TestFixture]
    public class ProjectRepositoryTests
    {
        [Test]
        public async System.Threading.Tasks.Task AddProjectTest()
        {
            var uow = UnitOfWorkFabric.CreateUnitOfWork();
            var project = new Project
            {
                Name = "Test name",
                Description = "test desc",
                DueDate = new DateTime(2000, 1, 1),
            };
            uow.ProjectRepository.Add(project);
            await uow.SaveChangesAsync();

            Assert.IsTrue(project.Id != 0);

            var addedProject = await uow.ProjectRepository.GetByIdAsync(project.Id);
            Assert.IsNotNull(addedProject);
            Assert.AreEqual("Test name", addedProject.Name);
            Assert.AreEqual("test desc", addedProject.Description);
            Assert.AreEqual(new DateTime(2000, 1, 1), addedProject.DueDate);
        }

        [Test]
        public async System.Threading.Tasks.Task EditProjectTest()
        {
            var uow = UnitOfWorkFabric.CreateUnitOfWork();
            var project = new Project
            {
                Name = "Test name",
                Description = "test desc",
                DueDate = new DateTime(2000, 1, 1),
            };
            uow.ProjectRepository.Add(project);
            await uow.SaveChangesAsync();

            var addedProject = await uow.ProjectRepository.GetByIdAsync(project.Id);
            Assert.IsNotNull(addedProject);

            addedProject.Name = "edited name";
            addedProject.Description = "edited desc";
            addedProject.DueDate = new DateTime(2001, 1, 1);

            uow.ProjectRepository.Update(addedProject);
            await uow.SaveChangesAsync();

            var editedProject = await uow.ProjectRepository.GetByIdAsync(project.Id);
            Assert.IsNotNull(editedProject);

            Assert.AreEqual("edited name", addedProject.Name);
            Assert.AreEqual("edited desc", addedProject.Description);
            Assert.AreEqual(new DateTime(2001, 1, 1), addedProject.DueDate);
        }

        [Test]
        public async System.Threading.Tasks.Task DeleteProjectTest()
        {
            var uow = UnitOfWorkFabric.CreateUnitOfWork();
            var project = new Project
            {
                Name = "Test name",
                DueDate = new DateTime(1999, 9, 9),
            };
            uow.ProjectRepository.Add(project);
            await uow.SaveChangesAsync();
            
            var addedProject = await uow.ProjectRepository.GetByIdAsync(project.Id);
            Assert.IsNotNull(addedProject);
            
            uow.ProjectRepository.Delete(addedProject);
            await uow.SaveChangesAsync();

            var deletedProject = await uow.ProjectRepository.GetByIdAsync(project.Id);
            Assert.IsNull(deletedProject);
        }

        [Test]
        public async System.Threading.Tasks.Task FindBySubstringTest()
        {
            var uow = UnitOfWorkFabric.CreateUnitOfWork();
            uow.ProjectRepository.Add(new Project
            {
                Name = "yellow blue",
                DueDate = new DateTime(1999, 9, 9),
            });
            uow.ProjectRepository.Add(new Project
            {
                Name = "blue red",
                DueDate = new DateTime(1999, 9, 19),
            });
            uow.ProjectRepository.Add(new Project
            {
                Name = "light green",
                DueDate = new DateTime(1999, 9, 5),
            });
            await uow.SaveChangesAsync();

            var projects = await uow.ProjectRepository.GetProjectsByNameAsync("blue");
            Assert.IsNotNull(projects);
            Assert.AreEqual(2, projects.Count);
        }
    }
}
