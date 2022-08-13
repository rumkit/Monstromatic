using System.Diagnostics;
using System.Threading.Tasks;

namespace Monstromatic.Utils;

public interface IProcessHelper
{
    void StartNew(string path);
    Task StartNewAndWaitAsync(string path);
}

public class ProcessHelper : IProcessHelper
{
    public void StartNew(string path)
    {
        var myProcess = new Process();
        myProcess.StartInfo.UseShellExecute = true; 
        myProcess.StartInfo.FileName = path;
        myProcess.Start();
    }

    public async Task StartNewAndWaitAsync(string path)
    {
        var myProcess = new Process();
        myProcess.StartInfo.UseShellExecute = true; 
        myProcess.StartInfo.FileName = path;
        myProcess.Start();
        await myProcess.WaitForExitAsync();
    }
}