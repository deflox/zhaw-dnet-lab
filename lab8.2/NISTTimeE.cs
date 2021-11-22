/*******************************************************************************
	Created by Saumit S. Sheth (saumit@execpc.com)
		   April 15, 2003
	Modified by K. Rege 
			Dezember 2006
	This program gets the official date and time from the NIST (ITS) timeserver
	and updates the system time on your computer.
*********************************************************************************/
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

public class NISTTime
{

	public struct SystemTime // win32 struct
	{
		public short wYear;
		public short wMonth;
		public short wDayOfWeek;
		public short wDay;
		public short wHour;
		public short wMinute;
		public short wSecond;
		public short wMilliseconds;
	};

	[DllImport("kernel32.dll")]
	static extern bool SetSystemTime(SystemTime time);

	public static void SetTime(DateTime localtime) {
		SystemTime time;
		time.wYear = (short) localtime.Year;
		time.wMonth = (short)localtime.Month;
		time.wDayOfWeek = (short)localtime.DayOfWeek;
		time.wDay = (short)localtime.Day;
		time.wHour = (short)localtime.Hour;
		time.wMinute = (short)localtime.Minute;
		time.wSecond = (short)localtime.Second;
		time.wMilliseconds = (short)localtime.Millisecond;

		Console.WriteLine(SetSystemTime(time));
	}
	
	public static DateTime GetUniversalTime()
		/*----------------------------------------------------------------------
		This method follows the Daytime Protocol (RFC 867). Visit www.ietf.org for more information.
		A socket is created to the timeserver IP address at port 13.  I hard-coded the main
		timeserver address, but other timeservers can be used, such as:
	
		time-a.nist.gov		time-b.nist.gov		utcnist.colorado.edu
		nist1.datum.com		nist1-ny.glassey.com	nist1.aol-ca.truetime.com
	
		Anything (I just send the "hello" string) can be sent to the timeserver.  What's returned (in ASCII) is:
	
		JJJJJ YR-MO-DA HH:MM:SS TT L H msADV UTC(NIST) OTM
	
		where JJJJJ is the Modified Julian Date, YR-MO-DA is the date, HH:MM:SS is the time,
		TT is a 2-digit indicator whether it is ST(00) or DST(50), L is whether a leap second will be added or subtracted
		at the end of the current month, H indicates health of server, msADV is num of ms NIST advances to compensate for
		network delays, UTC is a label always included, OTM is the on-time-marker, an '*'.
		Once the data is received, the socket is closed.  The information is parsed and a label displays the information.
		The SetSystemTime API function is called and the system time is updated.
		-------------------------------------------------------------------------*/
		
	{
		DateTime  universaltime;			// universaltime version
		string returndata = null;				// bytes returned from timeserver
		string[] dates = new string[4];			// year, month, day
		string[] times = new string[4];			// hour, minute, second
		string[] tokens = new string[11];		// bytes tokenized

		TcpClient tcpclient = new TcpClient();		// create new socket object

		tcpclient.Connect("time.nist.gov", 13);	// try to connect to timeserver

		NetworkStream networkStream = tcpclient.GetStream();
							// socket stream
		if (networkStream.CanWrite && networkStream.CanRead)
							// stream is ready
		{
			Byte[] sendBytes = Encoding.ASCII.GetBytes("Hello");
							// the hello string, Can be anything!
			networkStream.Write(sendBytes, 0, sendBytes.Length);
							// send to timeserver
  	
			byte[] bytes = new byte[tcpclient.ReceiveBufferSize];
			networkStream.Read(bytes, 0, (int) tcpclient.ReceiveBufferSize);
							// the official timeserver data  
			returndata = Encoding.ASCII.GetString(bytes);
							// cast as ASCII string
		}

		tcpclient.Close();			// close socket
		

		tokens = returndata.Split(' ');			// the timeserver data space parsed
		dates = tokens[1].Split('-');			// the date info hypen parsed
		times = tokens[2].Split(':');			// the time info colon parsed

		universaltime = new DateTime(Int32.Parse(dates[0]) + 2000, Int32.Parse(dates[1]), Int32.Parse(dates[2]),
					Int32.Parse(times[0]), Int32.Parse(times[1]), Int32.Parse(times[2]));
								// create a new datetime object with these values

		
		return universaltime;
		
	}

	
}
