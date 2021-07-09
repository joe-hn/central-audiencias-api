using System;

namespace SEJE.CORE.Abstractions
{
    public interface IBase
    {
    }

    public interface IBase<TKey, TUserKey> : IBase
    {
        public TKey Id { get; set; }
        public TUserKey CreatedById { get; set; }
        public DateTime CreationDate { get; set; }
        public TUserKey ModifiedById { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool Removed { get; set; }
    }
}
