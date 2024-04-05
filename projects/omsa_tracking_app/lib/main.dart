import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter/scheduler.dart';
import 'package:omsa_tracking_app/core/utils/navigator_service.dart';
import 'package:omsa_tracking_app/core/utils/pref_utils.dart';
import 'package:omsa_tracking_app/theme/provider/theme_provider.dart';
import 'package:provider/provider.dart';
import 'core/app_export.dart';

var globalMessengerKey = GlobalKey<ScaffoldMessengerState>();void main() {
  WidgetsFlutterBinding.ensureInitialized();
  Future.wait([
    SystemChrome.setPreferredOrientations([
      DeviceOrientation.portraitUp,
    ]),
    PrefUtils().init()
  ]).then((value) {
    runApp(MyApp());
  });
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Sizer(
      builder: (context, orientation, deviceType) {
        return ChangeNotifierProvider(
          create: (context) => ThemeProvider(),
          child: Consumer<ThemeProvider>(
            builder: (context, provider, child) {
              return MaterialApp(
                theme: theme,
                title: 'omsa_tracking',
                navigatorKey: NavigatorService.navigatorKey,
                debugShowCheckedModeBanner: false,
                supportedLocales: [
                  Locale(
                    'en',
                    '',
                  ),
                ],
                initialRoute: AppRoutes.stopBusesScreen,
                routes: AppRoutes.routes,
              );
            },
          ),
        );
      },
    );
  }
}

