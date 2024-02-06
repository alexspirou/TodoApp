using FluentAssertions;
using Moq;
using Todo.Application.Services;
using Todo.Application.Services.Interfaces;
using Todo.EFCore.Repositories;
using Todo.Models.Entities;
using Todo.Shared.Exceptions;

namespace Todo.Server.UnitTests
{
    public class TodoTaskTests
    {
  

        public TodoTaskTests()
        {
        }
        [Fact]
        public async Task MarkTodoTaskAsCompleted_Should_Throw_TodoTaskException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var cancellationToken = new CancellationToken();

            var mockRepository = new Mock<ITodoTaskRepository>();

            var completedTask = new TodoTask("Unit test task")
            {
                Id = id,
                IsDone = true
            };

            mockRepository.Setup(repo => repo.GetTodoTaskByIdAsync(id, cancellationToken))
                .ReturnsAsync(completedTask);


            var todoTaskService = new TodoTaskService(mockRepository.Object);
            // Act
            var action = async () => await todoTaskService.MarkTodoTaskAsCompletedAsync(id, cancellationToken);

            // Assert
            await action.Should().ThrowAsync<TodoTaskException>();


        }
    }
}