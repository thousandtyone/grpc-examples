# Examples of Various GRPC Capabilities and How You Can Use It.
The project just attempts to showcase various GRPC capabilities and what it can do. Each Capability is Checked in using a simple Folder.
Here Are some:

## HelloGrpc
Basic Example to Get Started with GRPC and Introduce You To the Client of Response Streams. Server Is a basic project that returns a list of hard coded users. To Simulate a Long Running Process between each user fetch artificial two second time interval is added. The server streams each use the to client instead of waiting for the whole query to finish. The Client Reads this stream and shows the data on the console as the data flows in instead of waiting for the response to end.


