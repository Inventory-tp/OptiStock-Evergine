namespace OptiStock.MAUI.Exceptions
{
    public static class GenericExceptions
    {
        public static readonly Exception CreationException = new("Can't create the given parameter");

        public static readonly Exception DeletionException = new("Can't delete the given parameter");

        public static readonly Exception UpdateException = new("Can't update the given parameter");

        public static readonly Exception GetAllException = new("Can't find any result for the given parameter");

        public static readonly Exception GetByIdException = new("Can't find a result for the given parameter");

        public static readonly Exception UnexpectedException = new("An unexpected exception have been catch while saving your updates");
    }
}
