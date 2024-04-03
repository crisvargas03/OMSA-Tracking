import 'package:http/http.dart' as http;
import 'dart:convert';

Future<void> fetchData() async {
  final response = await http.get(Uri.parse('https://localhost:7183/api/Bus'));
  if (response.statusCode == 200) {
    final data = json.decode(response.body);
    print(data);
  } else {
    throw Exception('Error al cargar los datos');
  }
}
