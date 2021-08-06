using System;

namespace Forbytes.Core.LanguageExtensions
{
    public readonly struct Result<T>
    {
        public T Value { get; init; }
        public ErrorModel Error { get; init; }

        private Result(in T value)
        {
            Value = value;
            Error = null;
        }

        private Result(in ErrorModel error)
        {
            Value = default;
            Error = error ?? throw new ArgumentNullException(nameof(error));
        }

        public static implicit operator Result<T>(in T value)
        {
            return new(value);
        }

        public static implicit operator Result<T>(in ErrorModel error)
        {
            return new(error);
        }

        public bool IsError => Error is not null;
        public bool IsSuccess => Error is null;
    }
}