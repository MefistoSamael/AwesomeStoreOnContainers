﻿using System.Runtime.Serialization;

namespace Identity.Application.Common.Exceptions;

public class ExistingUserException : Exception
{
    public ExistingUserException()
    {
    }

    public ExistingUserException(string? message) : base(message)
    {
    }

    public ExistingUserException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ExistingUserException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}