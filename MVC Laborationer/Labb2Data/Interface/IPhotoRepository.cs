using System;
using System.Collections.Generic;

namespace Labb2Data
{
    public interface IPhotoRepository
    {
        List<PhotoDataModel> GetPhotos();
        PhotoDataModel GetPhotoById(Guid id);
        void AddNewPhoto(PhotoDataModel photo);

        void DeletePhoto(Guid id);
        IEnumerable<PhotoDataModel> GetRecentUploads(int count);
    }
}