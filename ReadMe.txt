https://www.linkedin.com/uas/oauth2/authorization?response_type=code&client_id=86eiib65xp5z67&scope=r_basicprofile r_emailaddress&state=e1c3c574-9e54-4cd8-9d27-a16ede3e7f9a&redirect_uri=http:%2F%2Flocalhost:1883%2FLinkedPerson

User go to this link, authorize in LinkedIn, then redirects to http://{domain}/LinkedPerson
System will catch auth code from linkedin, and grab info about user(positions, firstaname, lastname, social_url...) and save to db.

You can change keys for yours own.
