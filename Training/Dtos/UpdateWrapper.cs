namespace Training.Dtos
{
    public class UpdateWrapper<T>
    {
        public bool Apply { get; set; } = false;
        public T? WrappedValue { get; set; }
    }
}
