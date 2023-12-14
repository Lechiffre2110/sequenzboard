using System.Collections;
using System.IO.Ports;
using UnityEngine;

public class BluetoothConnector : MonoBehaviour
{
    public static BluetoothConnector Instance;
    public Game2 game;

    private SerialPort serialPort;
    private string[] availablePorts;

    private float timer = 0f;
    private float interval = 1f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        availablePorts = GetBluetoothDevices();
        Debug.Log("Available ports: " + string.Join(", ", availablePorts));

        string selectedDevice = availablePorts[1];
        string connectionResult = StartBluetoothConnection(selectedDevice);

        if (connectionResult == "Connected")
        {
            Debug.Log("Bluetooth Connected!");
            Debug.Log(selectedDevice);
        }
        else
        {
            Debug.LogError("Error: " + connectionResult);
        }
        game = new Game2();
        WriteData(game.generateSeq(10));
    }

    void OnDestroy()
    {
        StopBluetoothConnection();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
       {
            ReadData();
            timer = 0f; 
       }
    }

    public string[] GetBluetoothDevices()
    {
        // Implement code to get available Bluetooth devices on your Mac
        // You can use System.IO.Ports.SerialPort.GetPortNames() to get available ports
        availablePorts = SerialPort.GetPortNames();
        return availablePorts;
    }

    public string StartBluetoothConnection(string portName)
    {
        try
        {
            serialPort = new SerialPort(portName, 9600);
            serialPort.Open();
            return "Connected";
        }
        catch (System.Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }

    public string ReadData()
    {
        try
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                return serialPort.ReadLine();
            }
            else
            {
                return "";
            }
        }
        catch (System.Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }

    public void WriteData(string data)
    {
        try
        {
            // Write data to the serial port
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.WriteLine(data);
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error: " + ex.Message);
        }
    }

    public void StopBluetoothConnection()
    {
        try
        {
            // Close the serial port
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error: " + ex.Message);
        }
    }
}
