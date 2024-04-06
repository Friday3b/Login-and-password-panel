using Microsoft.VisualBasic.ApplicationServices;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

// Abstract class istifadeciler ucun
abstract class User
{
    private String username;
    private String password;

    public User(String username, String password)
    {
        this.username = username;
        this.password = password;
    }

    // Encapsulation: sifresiz ilk girisden ugurlu giris
    public void setPassword(String password)
    {
        this.password = password;
    }

    // Abstraction: Abstract method giris ucun
    public abstract boolean login();

    // display ucun giris methodu
    public void displayLoginPrompts()
    {
        System.out.println("istifadeci adini daxil edin:");
        System.out.println("Sifreni daxil edin:");
    }
}

// NormalUser class giris normal istifadeciler ucun
class NormalUser extends User
{
    public NormalUser(String username, String password)
{
    super(username, password);
}

// Polymorphism: Override giriss metodu ve istifadeci
@Override
    public boolean login()
{
    displayLoginPrompts();
    Scanner scanner = new Scanner(System.in);
    String enteredUsername = scanner.nextLine();
    String enteredPassword = scanner.nextLine();
    return enteredUsername.equals(getUsername()) && enteredPassword.equals(getPassword());
}
}

// Admin istifadecisi Terefinden istifadeci girisi
class AdminUser extends User
{
    public AdminUser(String username, String password)
{
    super(username, password);
}

// Polymorphism: Admin paneli ve giris istifadesi
@Override
    public boolean login()
{
    displayLoginPrompts();
    Scanner scanner = new Scanner(System.in);
    String enteredUsername = scanner.nextLine();
    String enteredPassword = scanner.nextLine();
    // In this example, the admin username and password are hardcoded
    return enteredUsername.equals("admin") && enteredPassword.equals("adminpassword");
}
}

// Main class in funksiyalari testi
public class Main
{
    // Data structuru istifadecileri
    private static final Map<String, User> users = new HashMap<>();

    public static void main(String[] args)
    {
        // Yeni istifadeciler yarat
        users.put("user1", new NormalUser("user1", "user1password"));
        users.put("admin", new AdminUser("admin", "adminpassword"));

        // Perform login
        performLogin();
    }

    // Perform login methodu
    public static void performLogin()
    {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Systeme xosh gelmisiniz.");

        // Prompt istifadeci adi ve parolu ucun
        System.out.print("Adi daxil edin: ");
        String username = scanner.nextLine();
        System.out.print("Sifreni daxil edin: ");
        String password = scanner.nextLine();

        // istifadeci giris ve cixislarini yoxluyur
        User user = users.get(username);
        if (user != null && user.login())
        {
            System.out.println("Tebrikler Zorlada olsa daxil oldunuz!");
        }
        else
        {
            System.out.println("Invalid username or password. Please try again.");
            performLogin(); // yeniden girisi cagirir(again)
        }
    }
}
