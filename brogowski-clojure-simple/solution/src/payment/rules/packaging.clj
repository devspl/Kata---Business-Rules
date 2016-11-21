(ns payment.rules.packaging)
(use 'payment.rules.utils 'payment.utils)

(defn generate-packing-slip
  "Stub function for packaging slip generation/save/send."
  [product] (do
              (println (str "Packaging slip for: " product))
              {:products (list product)}))

(defn generate-duplicate-packaging-slip
  "Stub function for duplicate packaging slip generation/save/send."
  [packaging-slip] (do
                     (println (str "Duplicate packaging slip for: " packaging-slip))
                     packaging-slip))

(defn add-first-aid-movie-to-packaging-slip
  "Stub function for adding first aid movie to packagin slip"
  [packaging-slip]
  (let [products (:products packaging-slip)]
    (let [new-packaging-slip (assoc packaging-slip :products
                                                   (conj products {:types [:movie :physical]
                                                                   :title "First Aid"}))]
      (do (println (str "Added movie to: " new-packaging-slip))
          new-packaging-slip))))

(def packaging-payment-rules
  (list (build-chained-rules
          (build-chained-rule #(product-has-type? % :physical)
                              (fn [product & _] (generate-packing-slip product)))
          (build-chained-rule #(and (product-has-type? % :movie)
                                    (product-has-title? % "Learning to Ski"))
                              (fn [_ packaging-slip] (add-first-aid-movie-to-packaging-slip packaging-slip)))
          (build-chained-rule #(product-has-type? % :book)
                              (fn [_ packaging-slip] (generate-duplicate-packaging-slip packaging-slip))))))