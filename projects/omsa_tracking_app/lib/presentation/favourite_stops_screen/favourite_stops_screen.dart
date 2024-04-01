import 'package:omsa_tracking_app/widgets/custom_search_view.dart';
import 'package:omsa_tracking_app/widgets/custom_bottom_bar.dart';
import 'package:flutter/material.dart';
import 'package:omsa_tracking_app/core/app_export.dart';

class FavouriteStopsScreen extends StatelessWidget {
  FavouriteStopsScreen({Key? key})
      : super(
          key: key,
        );

  TextEditingController searchController = TextEditingController();

  GlobalKey<NavigatorState> navigatorKey = GlobalKey();

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        resizeToAvoidBottomInset: false,
        body: Container(
          width: double.maxFinite,
          padding: EdgeInsets.only(
            left: 20.h,
            top: 81.v,
            right: 20.h,
          ),
          child: Column(
            children: [
              Padding(
                padding: EdgeInsets.only(
                  left: 16.h,
                  right: 11.h,
                ),
                child: CustomSearchView(
                  controller: searchController,
                  hintText: "Buscar paradas",
                ),
              ),
              SizedBox(height: 23.v),
              Align(
                alignment: Alignment.centerLeft,
                child: Padding(
                  padding: EdgeInsets.only(left: 5.h),
                  child: Text(
                    "Paradas Favoritas",
                    style: CustomTextStyles.headlineSmallBold,
                  ),
                ),
              ),
              SizedBox(height: 22.v),
              _buildStopsContainer(context),
              SizedBox(height: 32.v),
              _buildStopsContainer1(context),
              SizedBox(height: 5.v),
            ],
          ),
        ),
        bottomNavigationBar: _buildBottomBar(context),
      ),
    );
  }

  /// Section Widget
  Widget _buildStopsContainer(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(left: 5.h),
      padding: EdgeInsets.symmetric(
        horizontal: 12.h,
        vertical: 13.v,
      ),
      decoration: AppDecoration.fillGray.copyWith(
        borderRadius: BorderRadiusStyle.roundedBorder16,
      ),
      child: Column(
        mainAxisSize: MainAxisSize.min,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: EdgeInsets.only(
              left: 8.h,
              right: 19.h,
            ),
            child: Row(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Expanded(
                  child: Container(
                    padding: EdgeInsets.symmetric(
                      horizontal: 9.h,
                      vertical: 7.v,
                    ),
                    decoration: AppDecoration.fillAmber.copyWith(
                      borderRadius: BorderRadiusStyle.roundedBorder8,
                    ),
                    child: Row(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(
                          "43B",
                          style: theme.textTheme.titleSmall,
                        ),
                        Padding(
                          padding: EdgeInsets.only(
                            left: 10.h,
                            bottom: 3.v,
                          ),
                          child: Text(
                            "Av. 27 de Febrero Proximo Av. Maximo Gomez",
                            style: CustomTextStyles.bodySmall10,
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
                CustomImageView(
                  imagePath: ImageConstant.imgArrowUpBlack900,
                  width: 18.h,
                  margin: EdgeInsets.only(
                    left: 32.h,
                    top: 6.v,
                    bottom: 7.v,
                  ),
                ),
              ],
            ),
          ),
          SizedBox(height: 12.v),
          Container(
            margin: EdgeInsets.only(left: 8.h),
            padding: EdgeInsets.symmetric(
              horizontal: 9.h,
              vertical: 13.v,
            ),
            decoration: AppDecoration.outlineBlack900.copyWith(
              borderRadius: BorderRadiusStyle.roundedBorder8,
            ),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.end,
              mainAxisSize: MainAxisSize.min,
              children: [
                CustomImageView(
                  imagePath: ImageConstant.imgCar,
                  width: 14.h,
                  margin: EdgeInsets.only(left: 7.h),
                ),
                Container(
                  height: 15.v,
                  width: 289.h,
                  margin: EdgeInsets.only(left: 25.h),
                  child: Stack(
                    alignment: Alignment.centerRight,
                    children: [
                      Align(
                        alignment: Alignment.center,
                        child: SizedBox(
                          width: 289.h,
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: [
                              Text(
                                "Bus B340M",
                                style: CustomTextStyles.bodySmallLight,
                              ),
                              Text(
                                "Vencida",
                                style: CustomTextStyles.labelLargeRed400,
                              ),
                            ],
                          ),
                        ),
                      ),
                      Align(
                        alignment: Alignment.centerRight,
                        child: Padding(
                          padding: EdgeInsets.only(right: 59.h),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            mainAxisSize: MainAxisSize.min,
                            children: [
                              CustomImageView(
                                imagePath: ImageConstant.imgUpload,
                                height: 14.v,
                                margin: EdgeInsets.only(bottom: 1.v),
                              ),
                              Padding(
                                padding: EdgeInsets.only(left: 6.h),
                                child: Text(
                                  "84 / 220",
                                  style: theme.textTheme.bodySmall,
                                ),
                              ),
                            ],
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
          SizedBox(height: 8.v),
          Padding(
            padding: EdgeInsets.only(left: 8.h),
            child: _buildStop2(
              context,
              weight: "Bus B347G",
              weight1: "Bus B347G",
              time: "6 min.",
              time1: "6 min.",
              sixtyEightThousandOneHundredFo: "68 / 140",
              sixtyEightThousandOneHundredFo1: "68 / 140",
            ),
          ),
          SizedBox(height: 8.v),
          Padding(
            padding: EdgeInsets.only(left: 8.h),
            child: _buildStop1(
              context,
              distance: "Bus C240M",
              eightyFourThousandTwoHundredTw: "140 / 140",
              vencida: "18 min.",
            ),
          ),
          SizedBox(height: 8.v),
        ],
      ),
    );
  }

  /// Section Widget
  Widget _buildStopsContainer1(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(left: 5.h),
      padding: EdgeInsets.symmetric(
        horizontal: 12.h,
        vertical: 13.v,
      ),
      decoration: AppDecoration.fillGray.copyWith(
        borderRadius: BorderRadiusStyle.roundedBorder16,
      ),
      child: Column(
        mainAxisSize: MainAxisSize.min,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: EdgeInsets.only(
              left: 8.h,
              right: 19.h,
            ),
            child: Row(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Expanded(
                  child: Container(
                    padding: EdgeInsets.symmetric(
                      horizontal: 9.h,
                      vertical: 7.v,
                    ),
                    decoration: AppDecoration.fillAmber.copyWith(
                      borderRadius: BorderRadiusStyle.roundedBorder8,
                    ),
                    child: Row(
                      children: [
                        Text(
                          "44A",
                          style: theme.textTheme.titleSmall,
                        ),
                        Padding(
                          padding: EdgeInsets.only(
                            left: 9.h,
                            top: 2.v,
                            bottom: 2.v,
                          ),
                          child: Text(
                            "Av. Kennedy Con Av. Maximo Gomez",
                            style: CustomTextStyles.bodySmall10,
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
                CustomImageView(
                  imagePath: ImageConstant.imgArrowUpBlack900,
                  width: 18.h,
                  margin: EdgeInsets.only(
                    left: 37.h,
                    top: 6.v,
                    bottom: 7.v,
                  ),
                ),
              ],
            ),
          ),
          SizedBox(height: 12.v),
          Padding(
            padding: EdgeInsets.only(left: 8.h),
            child: _buildStop1(
              context,
              distance: "Bus B340M",
              eightyFourThousandTwoHundredTw: "84 / 220",
              vencida: "Vencida",
            ),
          ),
          SizedBox(height: 8.v),
          Padding(
            padding: EdgeInsets.only(left: 8.h),
            child: _buildStop2(
              context,
              weight: "Bus B347G",
              weight1: "Bus B347G",
              time: "6 min.",
              time1: "6 min.",
              sixtyEightThousandOneHundredFo: "68 / 140",
              sixtyEightThousandOneHundredFo1: "68 / 140",
            ),
          ),
          SizedBox(height: 8.v),
          Padding(
            padding: EdgeInsets.only(left: 8.h),
            child: _buildStop1(
              context,
              distance: "Bus C240M",
              eightyFourThousandTwoHundredTw: "140 / 140",
              vencida: "18 min.",
            ),
          ),
          SizedBox(height: 12.v),
        ],
      ),
    );
  }

  /// Section Widget
  Widget _buildBottomBar(BuildContext context) {
    return CustomBottomBar(
      onChanged: (BottomBarEnum type) {},
    );
  }

  /// Common widget
  Widget _buildStop1(
    BuildContext context, {
    required String distance,
    required String eightyFourThousandTwoHundredTw,
    required String vencida,
  }) {
    return Container(
      padding: EdgeInsets.symmetric(
        horizontal: 9.h,
        vertical: 13.v,
      ),
      decoration: AppDecoration.outlineBlack900.copyWith(
        borderRadius: BorderRadiusStyle.roundedBorder8,
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.end,
        mainAxisSize: MainAxisSize.min,
        children: [
          CustomImageView(
            imagePath: ImageConstant.imgCar,
            width: 14.h,
            margin: EdgeInsets.only(left: 7.h),
          ),
          Padding(
            padding: EdgeInsets.only(
              left: 25.h,
              top: 2.v,
            ),
            child: Text(
              distance,
              style: CustomTextStyles.bodySmallLight.copyWith(
                color: appTheme.black900,
              ),
            ),
          ),
          Spacer(),
          CustomImageView(
            imagePath: ImageConstant.imgUpload,
            height: 14.v,
            margin: EdgeInsets.only(bottom: 2.v),
          ),
          Padding(
            padding: EdgeInsets.only(
              left: 6.h,
              top: 2.v,
            ),
            child: Text(
              eightyFourThousandTwoHundredTw,
              style: theme.textTheme.bodySmall!.copyWith(
                color: appTheme.black900,
              ),
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
              left: 15.h,
              top: 2.v,
            ),
            child: Text(
              vencida,
              style: CustomTextStyles.labelLargeRed400.copyWith(
                color: appTheme.red400,
              ),
            ),
          ),
        ],
      ),
    );
  }

  /// Common widget
  Widget _buildStop2(
    BuildContext context, {
    required String weight,
    required String weight1,
    required String time,
    required String time1,
    required String sixtyEightThousandOneHundredFo,
    required String sixtyEightThousandOneHundredFo1,
  }) {
    return Container(
      padding: EdgeInsets.symmetric(
        horizontal: 11.h,
        vertical: 13.v,
      ),
      decoration: AppDecoration.outlineBlack900.copyWith(
        borderRadius: BorderRadiusStyle.roundedBorder8,
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.end,
        mainAxisSize: MainAxisSize.min,
        children: [
          CustomImageView(
            imagePath: ImageConstant.imgCar,
            width: 14.h,
            margin: EdgeInsets.only(left: 6.h),
          ),
          Container(
            height: 15.v,
            width: 287.h,
            margin: EdgeInsets.only(left: 24.h),
            child: Stack(
              alignment: Alignment.centerRight,
              children: [
                Align(
                  alignment: Alignment.center,
                  child: SizedBox(
                    width: 287.h,
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        SizedBox(
                          height: 15.v,
                          width: 59.h,
                          child: Stack(
                            alignment: Alignment.center,
                            children: [
                              Align(
                                alignment: Alignment.center,
                                child: Text(
                                  weight,
                                  style:
                                      CustomTextStyles.bodySmallLight.copyWith(
                                    color: appTheme.black900,
                                  ),
                                ),
                              ),
                              Align(
                                alignment: Alignment.center,
                                child: Text(
                                  weight1,
                                  style:
                                      CustomTextStyles.bodySmallLight.copyWith(
                                    color: appTheme.black900,
                                  ),
                                ),
                              ),
                            ],
                          ),
                        ),
                        SizedBox(
                          height: 15.v,
                          width: 34.h,
                          child: Stack(
                            alignment: Alignment.center,
                            children: [
                              Align(
                                alignment: Alignment.center,
                                child: Text(
                                  time,
                                  style: theme.textTheme.labelLarge!.copyWith(
                                    color: appTheme.black900,
                                  ),
                                ),
                              ),
                              Align(
                                alignment: Alignment.center,
                                child: Text(
                                  time1,
                                  style: theme.textTheme.labelLarge!.copyWith(
                                    color: appTheme.black900,
                                  ),
                                ),
                              ),
                            ],
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
                Align(
                  alignment: Alignment.centerRight,
                  child: Padding(
                    padding: EdgeInsets.only(right: 57.h),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        Container(
                          height: 14.v,
                          width: 15.h,
                          margin: EdgeInsets.only(bottom: 1.v),
                          child: Stack(
                            alignment: Alignment.center,
                            children: [
                              CustomImageView(
                                imagePath: ImageConstant.imgUpload,
                                height: 14.v,
                                alignment: Alignment.center,
                              ),
                              CustomImageView(
                                imagePath: ImageConstant.imgUpload,
                                height: 14.v,
                                alignment: Alignment.center,
                              ),
                            ],
                          ),
                        ),
                        Container(
                          height: 15.v,
                          width: 45.h,
                          margin: EdgeInsets.only(left: 6.h),
                          child: Stack(
                            alignment: Alignment.center,
                            children: [
                              Align(
                                alignment: Alignment.center,
                                child: Text(
                                  sixtyEightThousandOneHundredFo,
                                  style: theme.textTheme.bodySmall!.copyWith(
                                    color: appTheme.black900,
                                  ),
                                ),
                              ),
                              Align(
                                alignment: Alignment.center,
                                child: Text(
                                  sixtyEightThousandOneHundredFo1,
                                  style: theme.textTheme.bodySmall!.copyWith(
                                    color: appTheme.black900,
                                  ),
                                ),
                              ),
                            ],
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
