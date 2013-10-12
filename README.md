## Introduction

Log4Error helps capture most relevant logging messages from across the system without writing additional line in the code. It just simplifies the error from stack trace to simple error messages.


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

All one needs to do is to add annotations to the methods about their relevance.
 
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

If an exception is thrown from IsBlackListed method the message you can get using this library would be :

      Make Payment -> Verifying credit card information -> Is card black listed


Here you have an error message which can be understood by anyone, and you can focus on the right method and resolve the issue fast. 

No more stack trace parsing.

No more source code knowledge required.

AND

If you want to use this library properly, you will need to write modular code. Code quality improvement for free :)
