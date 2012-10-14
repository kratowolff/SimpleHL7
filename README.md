Simple HL7 Parser and Handler
=============================

.NET Class library parses HL7 v2.3 messages and provides handlers that can be configured to respond to inbound messages.  This project is currently in a preliminary/unstable state.

Intro
-----

I was looking for a lightweight HL7 parser that I could use to tanslate inbound HL7 messages into stored procedure calls in our database.  The closest project I could find to suit my needs was [NHapi](http://nhapi.sourceforge.net), but I found that in some ways NHapi was overkill for what I needed and in other ways, it didn't provide some of the features that I was interested in.  So I created this project.  Hopefully it will be of use to some others too.
