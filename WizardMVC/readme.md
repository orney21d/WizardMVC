http://www.binaryintellect.net/articles/9a5fe277-6e7e-43e5-8408-a28ff5be7801.aspx

To develop a wizard in ASP.NET MVC you will use the following approach:

Each wizard step will have an action method in the controller and a view.
The data accepted in each wizard step is stored in a view model class designed for that step.
All the action methods for wizard steps will accept three parameters - step's view model object and two string parameters indicating the Next / Previous status.
The action methods mentioned above grab the data from view model object and store it in Session till the final step.
The action methods return a view for the next step if Next button is clicked. If Previous button is clicked they return a view for the previous step and they return the same view if there are any model validation errors.
Model validations are checked only when Next button is clicked.