### Building and Running Solution/Tests

The solution was built in Visual Studio 2019. The easiest way to run everything is open the BabysitterKada.sln in Visual Studio and build the solution to create the executable.

Tests were written with MSTest. If you have MSTest installed you can run the command

dotnet test 

From the BabySitterKadaTests directory in command line. But again, easier to use the test explorer in Visual Studio.

I don't have any experience building c# solutions outside of Visual Studio so I'm hoping if you don't use VS you know better how to do it then me!

### Notes on solution and asssumptions made

**Assumption #1: Dates do not matter.**

Any public method taking a time input takes it as a string such as `6:30PM` or `1:00AM`. No date is ever entered.
I initially took DateTime objects as inputs, but it was cumbersome to test with, and also made it difficult to compare with fixed times such as those required by the different pay windows.

So instead, strings are converted behind the scenes to DateTimes with today's date, or if an AM time,
today's date + 1 day.  This was a consideration on how to 
represent times internally that I went back and forth on.  Because we are always calculating 1 night only and there is no reporting or receipt
component to the Kada mentioned, I felt this was a reliable way to represent time.

**Assumption #2:  No Pay For Fractional Hours**

I interpreted this requirement in a very particular way after thinking during writing a test.  I interpeted this as you can be paid for fractional hours
at a particular rate, but not fractional hours for total hours worked.

For example. If Family C has a rate switch at 9:00PM, and a babysitter works 8:30PM to 10:30PM, they worked 2 total hours.

However, the breakdown is .5 hours at rate 1, and 1.5 hours at rate 2.  Ignoring fractional hours completely as I initially interpreted it would
pay this as 1 hour only, which seems unfair to the BabySitter considering they worked 2 full hours! So my solution would pay this scenario at .5 hours Rate 1, and 1.5 Hours at Rate 2. 

However, if the time worked was from 8:30PM to 11:00PM, that is 2.5 total hours worked.
Although the Babysitter worked .5 hours at rate 1 and 2.0 hours at rate 2, because total hours is a fraction, the Babysitter will only be paid for .5 hours at Rate 1
and 1.5 hours at Rate 2 for a TOTAL of 2.0 hours.

You can see this in action most clearly in FamilyBIntegrationTests, because the hours worked hop around to different rates quite a bit.