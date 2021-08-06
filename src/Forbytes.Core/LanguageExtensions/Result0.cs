using System;
using System.Threading.Tasks;

namespace Forbytes.Core.LanguageExtensions
{
    public readonly struct Result
    {
        public static readonly Result Success = new ();
        public static readonly Task<Result> SuccessTask = Task.FromResult(Success);

        public ErrorModel Error { get; init; }

        private Result(in ErrorModel error)
        {
            Error = error ?? throw new ArgumentNullException(nameof(error));
        }

        public static implicit operator Result(in ErrorModel error)
        {
            return new(error);
        }

        public bool IsError => Error is not null;
        public bool IsSuccess => Error is null;
    }
}