class Driver {
  String name;
  String lastName;
  String identificationDocument;
  int busId;

  Driver({
    required this.name,
    required this.lastName,
    required this.identificationDocument,
    required this.busId,
  });

  factory Driver.fromJson(Map<String, dynamic> json) {
    return Driver(
      name: json['name'],
      lastName: json['lastName'],
      identificationDocument: json['identificationDocument'],
      busId: json['busId'],
    );
  }
}
