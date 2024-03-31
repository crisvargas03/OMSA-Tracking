import 'package:flutter/material.dart';

class InitialScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Container(
              margin: EdgeInsets.only(bottom: 20),
              child: TextButton(
                onPressed: () {
                  print('Button pressed');
                },
                child: Text(
                  'Activar Ubicación',
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                    fontSize: 16,
                  ),
                ),
                style: TextButton.styleFrom(
                  foregroundColor: Color(0xFF1D1D1D),
                  backgroundColor: Color(0xFFFDE150),
                  padding: const EdgeInsets.symmetric(horizontal: 30, vertical: 10),
                  minimumSize: Size(199, 45),
                ),
              ),
            ),
            TextButton(
              onPressed: () {
                print('Link pressed');
              },
              child: Text(
                'Buscaré Manualmente',
                style: TextStyle(
                  color: Color(0xFF000000),
                  fontSize: 16,
                  decoration: TextDecoration.underline,
                  fontWeight: FontWeight.w300, // lighter font weight
                ),
              ),
              style: TextButton.styleFrom(
                backgroundColor: Colors.transparent,
                minimumSize: Size(175, 32),
              ),
            ),
          ],
        ),
      ),
    );
  }
}