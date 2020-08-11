namespace Services.Configuration
{
    using System.Collections.Generic;

    internal static class MappingExtension
    {
        public static TDestination ToViewModel<TDestination>(this object source)
        {
            return AutoMapper.Mapper.Map<TDestination>(source);
        }

        public static IEnumerable<TDestination> ToEnumerableViewModel<TDestination>(this object source)
        {
            return AutoMapper.Mapper.Map<IEnumerable<TDestination>>(source);
        }
    }
}