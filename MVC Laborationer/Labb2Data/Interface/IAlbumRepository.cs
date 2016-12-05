using System;
using System.Collections.Generic;

namespace Labb2Data
{
    public interface IAlbumRepository
    {
        List<AlbumDataModel> GetAlbums();
        AlbumDataModel GetAlbumById(Guid id);

        void SavePhotoInAlbum(Guid id, PhotoDataModel photo);
        void AddNewAlbum(AlbumDataModel album, Guid userId);

        void DeleteAlbum(Guid id);

    }
}