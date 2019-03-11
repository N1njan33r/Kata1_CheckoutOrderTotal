# Checkout Order Total

This API can be integrated into a standard POS system to accept a unique identifier of a product in the store (as well as other parameters) and return the total price of all added items, pre-tax. This can include marked-down prices, sales, bulk prices, and quantity limits. It also contains methods for removing an item regardless of any special cases, provided those parameters are specified in the API call.
```
git clone git@github.com:N1njan33r/Kata1_CheckoutOrderTotal.git
```

## Getting Started

'git clone' the repository using the following command:


### Prerequisites

* Visual Studio (2017 or later)

### Installing

Can be deployed as a web service API to be run from a server. 

## Running the tests

All tests are self-contained and can be run directly from the Visual Studio test suite.

### Unit Testing

These tests will run through each method to ensure that the proper output is given.

#### Example:

```
GetAllItems_ShouldReturnAllItems()
```
This will return all items present in the sample list and show a green status if the number of JSON objects returned is the same as the number of objects asserted.

## Author

* **Alexander Inman** - *Initial work* - [N1njan33r](https://github.com/N1njan33r)

See also the list of [contributors](https://github.com/N1njan33r/Kata1_CheckoutOrderTotal/contributors) who participated in this project.

## License

All rights reserved.

## Acknowledgments

* A wonderful shoutout to Pillar Technology for the opportunity to exercise my programming knowledge with this code kata.