﻿namespace MusicStore.Domain.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
