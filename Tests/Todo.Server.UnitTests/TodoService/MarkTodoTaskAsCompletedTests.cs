using FluentAssertions;
using Moq;
using Todo.Application.Services;
using Todo.Application.Services.Interfaces;
using Todo.EFCore.Repositories;
using Todo.Models.Entities;

namespace Todo.Server.UnitTests.TodoService
{
    public class MarkTodoTaskAsCompletedTests
    {
        private readonly Mock<ITodoTaskRepository> _mockRepo;
        public MarkTodoTaskAsCompletedTests()
        {
            _mockRepo = new Mock<ITodoTaskRepository>();
        }
        [Fact]
        public void When_GivenTodoIdNotFound_Then_Throw_NullReferenceException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var cancellationToken = new CancellationToken();
            var completedTask = new TodoTask("Unit test task")
            {
                Id = id,
                IsDone = true
            };

            _mockRepo.Setup(repo => repo.GetTodoTaskByIdAsync(id, cancellationToken))
                .ReturnsAsync(completedTask);


            var sut = CreateSut();

            // Act
            var action = () =>sut.MarkTodoTaskAsCompletedAsync(completedTask.Id);

            // Assert
            action.Should().ThrowAsync<Exception>();
        }

        private ITodoTaskService CreateSut()
        {
            var todoTaskService = new TodoTaskService(_mockRepo.Object);
            return todoTaskService;
        }
    }
}
