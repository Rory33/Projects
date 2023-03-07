import java.sql.Connection;
import java.sql.DriverManager;

import javax.swing.JOptionPane;

public class SqliteConnection {
	
public static Connection dbConnection() {
		
		try {
			Class.forName("org.sqlite.JDBC");
			Connection conn = DriverManager.getConnection("jdbc:sqlite:Studentdb.db");
			JOptionPane.showMessageDialog(null, "You have connected to the Database");
			
			return conn;
			
		} catch (Exception e) {
			// TODO: handle exception

			JOptionPane.showMessageDialog(null, e.getMessage());
			
			return null;
		}
	}

}
