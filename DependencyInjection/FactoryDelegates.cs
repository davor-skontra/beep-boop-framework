namespace DependencyInjection
{
    public delegate TResult Factory<TResult>();
    public delegate TResult Factory<TOne, TResult>(TOne dependencyOne);
    public delegate TResult Factory<TOne, TTwo, TResult>(TOne dependencyOne, TTwo dependencyTwo);
    public delegate TResult Factory<TOne, TTwo, TThree, TResult>(TOne dependencyOne, TTwo dependencyTwo, TThree dependencyThree);
    public delegate TResult Factory<TOne, TTwo, TThree, TFour, TResult>(TOne dependencyOne, TTwo dependencyTwo, TThree dependencyThree, TFour dependencyFour);
}