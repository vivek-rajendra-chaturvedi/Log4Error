## Introduction

Log4Error helps capture most relevant messages for logging from across the system without writing additional lines in the code. It just simplifies the error from stack trace to simple error messages.


## How to configure

Add the following section to your config file

  	<configSections>
        <section name="Log4Error" type="Log4Error.Configuration.Log4ErrorSection, Log4Error" />
	</configSections>

	<Log4Error>
		<Assemblies>
			<Assembly name="{name_of_dll_which_has_the_annotations}"/>
			<Assembly name="..."/>
		</Assemblies>
	</Log4Error>
 
## How to use :


Initialise the Log4Error on application start

        new Log4Error.Log4Error();

Add the following line to some common exception handling place or wherever you want to catch the exception.

      String errorMessage = Log4Error.Log4Error.GetErrorMessage(exception);

All one needs to do is to add annotations to the methods with a relevant message.
 
        [ErrorMessage("Make Payment")]
        public void MakePayment(...)
        {
            ...
            VerifyPaymentInfo(...);
            ...
        }

        [ErrorMessage("Verifying credit card information")]
        public void VerifyPaymentInfo(...)
        {
            ...
            IsBlackListed(...);
            ... 
        }

        [ErrorMessage("Is card black listed")]
        public void IsBlackListed(...)
        {
            ...
        }

If an exception is thrown from IsBlackListed method, the message you will get would be:

      Make Payment -> Verifying credit card information -> Is card black listed


Here you have an error message which can be understood by anyone, and you can focus on the right part of the code and resolve the issue faster. 



## Benefits :

 No more stack trace parsing.

 No more source code knowledge required.


## Additional Benefit :

 If you want to use this library to it's best, you would be required to write modular code :)
