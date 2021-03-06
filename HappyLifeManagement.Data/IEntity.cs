﻿using System;

namespace HappyLifeManagement.Data
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }

    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
