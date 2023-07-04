namespace SurveyConfiguratorApp.Logic.Comman
{
    public interface ICRUD<T>
    {
        bool add(T data);
        bool update(T data);
        T Get(int id);
    }
}
