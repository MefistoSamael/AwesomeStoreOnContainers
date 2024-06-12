﻿namespace EventBus.Domain.Entities;

public abstract class Event
{
    public DateTime TimeStamp { get; protected set; }

    protected Event()
    {
        TimeStamp = DateTime.Now;
    }
}
