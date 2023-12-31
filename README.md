<h2>AccountingService</h2>

<h3>About</h3>

This API purpose is to to be an accounting service that implements the folowing set of requirements:

- The API will expose an endpoint which accepts the user information (customerID,
initialCredit).
- Once the endpoint is called, a new account will be opened connected to the user
whose ID is customerID.
- Also, if initialCredit is not 0, a transaction will be sent to the new account.
- Another Endpoint will output the user information showing Name, Surname,
balance, and transactions of the accounts.

<h3>Setup</h3>

The API is dockerized which means that it should be relatively easy for to get it up and running. For you to get it
running first clone this git repository to your machine. Open terminal and navigate to the root of the cloned repo,
the use the following command:

``` docker-compose up ```

The process may take a while but eventually the service will be up and running. If you get any error regarding missing
images just use the following command to each missing image:

``` docker pull <missing_image> ```

After the docker containers creation open visual studio, choose to run the executable "AccountingService" at the run dropdown menu and everything should be set.

<h3>Usage</h3>

After the project is running, your browser should open the API's swagger page for easy testing.

</h2>List accounts Endpoint</h2>

Verb: GET

This endpoint is used to list existing accounts on the database.

The conversion endpoint route (locally) is:
``` https://localhost:7203/Account' ```

Below is the curl for calling the conversion endpoint (locally):

curl -X 'GET' \
  'https://localhost:7203/Account' \
  -H 'accept: */*'

</h2>Create Account Endpoint</h2>

This endpoint is used to create new accounts

Verb: POST

The create new account endpoint route (locally) is:
``` https://localhost:7203/Account ```

Body:

{
  "customerId": "{customerId}",
  "initialCredit": "{initialCredit string in Double format}"
}

Parameters:
- customerId: string for customer id;
- initialCredit: string in Double number format;

Below is the curl for calling the add currency endpoint (locally):

curl -X 'POST' \
  'https://localhost:7203/Account' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "customerId": "string",
  "initialCredit": "string"
}'

Notice: Please observe that the Double number format was chosen due to comply with legislation regarding monetary transactions, also the following rules will when sending a create
account request will be enforced:
- Request must have valid body;
- Initial credit value has to be a number in Double format;
- Initial credit value cannot be lesser than zero;
- If Customer already has an account, another account will NOT be created.

<h3>Important Notice</h3>

Currently, the API has no unit tests as originally planned, this is due purely to time constraints. Also where may be problems regarding migrations execution, if that happens
delete all tables on the database, as well as the "Migrations" folder on the project. After that on visual studio open the Packer Manager Console and use the following command:
``` add-migration initial ```. The project should execute normally afterwards. In the scenario in which the user is still having problems to execute the solution please
contact me via: thalespfachinelli@gmail.com for further help. It is also important to note that I haven't coded in
.Net since 2021 so it's been a while...
