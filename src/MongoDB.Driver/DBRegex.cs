//COPYRIGHT
namespace MongoDB.Driver {

/**
 * Use java.util.regex.Pattern for regular expressions.
 * @deprecated
 */
public class DBRegex {

    private string _pattern;
    private string _options;

    public DBRegex(string p, string o) {
        _pattern = p;
        _options = o;
    }

    public string getPattern() {
        return _pattern;
    }

    public string getOptions() {
        return _options == null ? "" : _options;
    }
}
}