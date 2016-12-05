using System;

namespace Labb2Data
{
    public interface ICommentRepository
    {
        void AddNewComment(Guid photoId, CommentDataModel comment);
        void DeleteComment(Guid commentId);
    }
}