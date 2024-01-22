﻿using Todo.EFCore.Repositories.Common;
using Todo.Models.Entities;

namespace Todo.EFCore.Repositories
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {
        Task<Comment> CreateCommentAsync(Comment comment);
    }
}
