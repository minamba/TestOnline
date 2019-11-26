using System;

public interface Ilog
{
    void Information(string message);
    void Warning(string message);
    void Debug(string message);
    void Error(string message);
}
