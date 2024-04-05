import 'package:omsa_tracking_app/core/utils/navigator_service.dart';
import 'widgets/stop_buses_item_widget.dart';
import 'models/stop_buses_item_model.dart';
import 'models/stop_buses_model.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:omsa_tracking_app/core/app_export.dart';
import 'provider/stop_buses_provider.dart';

class StopBusesScreen extends StatefulWidget {
  const StopBusesScreen({Key? key})
      : super(
          key: key,
        );

  @override
  StopBusesScreenState createState() => StopBusesScreenState();

  static Widget builder(BuildContext context) {
    return ChangeNotifierProvider(
      create: (context) => StopBusesProvider(),
      child: StopBusesScreen(),
    );
  }
}

class StopBusesScreenState extends State<StopBusesScreen> {
  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        backgroundColor: theme.colorScheme.onPrimaryContainer,
        body: Container(
          width: double.maxFinite,
          decoration: AppDecoration.fillGray.copyWith(
            borderRadius: BorderRadiusStyle.customBorderTL32,
          ),
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              _buildStopBusesHeader(context),
              Container(
                padding: EdgeInsets.symmetric(
                  horizontal: 38.h,
                  vertical: 51.v,
                ),
                decoration: AppDecoration.fillGray,
                child: Column(
                  children: [SizedBox(height: 60.v), _buildStopBuses(context)],
                ),
              )
            ],
          ),
        ),
        bottomNavigationBar: _buildBottomBar(context),
      ),
    );
  }

  /// Section Widget
  Widget _buildStopBusesHeader(BuildContext context) {
    return Container(
      width: double.maxFinite,
      padding: EdgeInsets.symmetric(
        horizontal: 20.h,
        vertical: 22.v,
      ),
      decoration: AppDecoration.fillAmber,
      child: Row(
        mainAxisAlignment: MainAxisAlignment.end,
        crossAxisAlignment: CrossAxisAlignment.end,
        children: [
          CustomImageView(
            imagePath: ImageConstant.imgArrowLeft,
            height: 21.adaptSize,
            width: 21.adaptSize,
            margin: EdgeInsets.only(
              left: 5.h,
              top: 45.v,
              bottom: 8.v,
            ),
            onTap: () {
              onTapImgArrowLeft(context);
            },
          ),
          Padding(
            padding: EdgeInsets.only(
              left: 9.h,
              top: 41.v,
              bottom: 5.v,
            ),
            child: Text(
              "lbl_43b",
              style: theme.textTheme.headlineSmall,
            ),
          ),
          Container(
            width: 211.h,
            margin: EdgeInsets.only(
              left: 15.h,
              top: 37.v,
            ),
            child: Text(
              "msg_av_27_de_febrero",
              maxLines: 2,
              overflow: TextOverflow.ellipsis,
              style: theme.textTheme.bodyLarge,
            ),
          ),
          Spacer(),
          CustomImageView(
            imagePath: ImageConstant.imgFavorite,
            height: 24.v,
            margin: EdgeInsets.only(
              top: 44.v,
              bottom: 6.v,
            ),
          )
        ],
      ),
    );
  }

  /// Section Widget
  Widget _buildStopBuses(BuildContext context) {
    return Padding(
      padding: EdgeInsets.only(left: 1.h),
      child: Consumer<StopBusesProvider>(
        builder: (context, provider, child) {
          return ListView.separated(
            physics: NeverScrollableScrollPhysics(),
            shrinkWrap: true,
            separatorBuilder: (context, index) {
              return SizedBox(
                height: 15.v,
              );
            },
            itemCount: provider.stopBusesModelObj.stopBusesItemList.length,
            itemBuilder: (context, index) {
              StopBusesItemModel model =
                  provider.stopBusesModelObj.stopBusesItemList[index];
              return StopBusesItemWidget(
                model,
              );
            },
          );
        },
      ),
    );
  }

  /// Section Widget
  Widget _buildBottomBar(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
        color: theme.colorScheme.onPrimaryContainer,
        boxShadow: [
          BoxShadow(
            color: appTheme.black900.withOpacity(0.2),
            spreadRadius: 2.h,
            blurRadius: 2.h,
            offset: Offset(
              -1,
              -1,
            ),
          )
        ],
      ),
      child: CustomImageView(
        imagePath: ImageConstant.imgCar, // Continue here 
        height: 32.v,
        margin: EdgeInsets.fromLTRB(41.h, 16.v, 40.h, 16.v),
      ),
    );
  }

  /// Navigates to the previous screen.
  onTapImgArrowLeft(BuildContext context) {
    NavigatorService.goBack();
  }
}
