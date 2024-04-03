class ApiResponse {
  int statusCode;
  bool isSuccess;
  List<String> errorMessages;
  dynamic payload;

  ApiResponse({
    required this.statusCode,
    required this.isSuccess,
    required this.errorMessages,
    required this.payload,
  });
}
